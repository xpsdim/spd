import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Rx';

import { BaseService } from "./base.service";
import { ConfigService } from '../utils/config.service';
import { ChangePassword } from '../../shared/models/change.password';

@Injectable()
export class ProfileService extends BaseService {

  //TODO move baseurl into base service class
  baseUrl: string = '';

  constructor(private http: Http, private configService: ConfigService) {
    super();
    this.baseUrl = configService.getApiURI();
  }

  changePassword(userid: string, oldPassword: string, newPassword: string, repeatNewPassword: string) {

  }

  getChangePasswordData(): Observable<ChangePassword> {    
    return this.http.post(this.baseUrl + '/profile', null)
      .map((response: Response) => {
        const result = response.json();
        return result;
      })
      .catch((error: Response | any) => {
        return Observable.throw(error.statusText);
      });
  }
}
