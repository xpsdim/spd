import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';

import { UserRegistration } from '../models/user.registration.interface';
import { ConfigService } from '../utils/config.service';

import { BaseService } from "./base.service";

import { Observable } from 'rxjs/Rx';
import { BehaviorSubject } from 'rxjs/Rx';


@Injectable()
export class UserService extends BaseService {

  baseUrl: string = '';

  // Observable navItem source
  private _authNavStatusSource = new BehaviorSubject<boolean>(false);
  // Observable navItem stream
  authNavStatus$ = this._authNavStatusSource.asObservable();

  private loggedIn = false;

  constructor(private http: Http, private configService: ConfigService) {
    super();
    this.loggedIn = !!localStorage.getItem('auth_token');
    // ?? not sure if this the best way to broadcast the status but seems to resolve issue on page refresh where auth status is lost in
    // header component resulting in authed user nav links disappearing despite the fact user is still logged in
    this._authNavStatusSource.next(this.loggedIn);
    this.baseUrl = configService.getApiURI();
  }

  register(email: string, password: string, realName: string): Observable<boolean> {
    let body = JSON.stringify({ email, password, realName });
    return this.http.post(this.baseUrl + "/accounts", body)
      .map(res => true)
      .catch(this.handleError);
  }

  login(userName, password) {    
    return this.http
      .post(
        this.baseUrl + '/token', JSON.stringify({ userName, password })
      )
      .map(res => res.json())
      .map(res => {
        //--------------------------------------        

        let jwtData = res.token.split('.')[1]
        let decodedJwtJsonData = window.atob(jwtData)
        let decodedJwtData = JSON.parse(decodedJwtJsonData)        
        console.log(decodedJwtData)
        
        //--------------------------------------

        localStorage.setItem('auth_token', res.token);
        this.loggedIn = true;
        this._authNavStatusSource.next(true);
        return true;
      })
      .catch(e => {
        if (e.status === 401) {
          return Observable.throw("User '" + userName + "' not found.");
        }
        return this.handleError
      });
  }

  logout() {
    localStorage.removeItem('auth_token');
    this.loggedIn = false;
    this._authNavStatusSource.next(false);
  }

  isLoggedIn() {
    return this.loggedIn;
  }

  facebookLogin(accessToken: string) {    
    let body = JSON.stringify({ accessToken });    
    return this.http
      .post(
      this.baseUrl + '/externalauth/facebook', body)
      .map(res => res.json())
      .map(res => {
        localStorage.setItem('auth_token', res.auth_token);
        this.loggedIn = true;
        this._authNavStatusSource.next(true);
        return true;
      })
      .catch(this.handleError);
  }
  
}
