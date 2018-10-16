import { Observable } from 'rxjs/Rx';
import { Http, Headers } from '@angular/http';

const AUTH_HEADER_KEY = 'Authorization';
const AUTH_PREFIX = 'Bearer';

export abstract class BaseService {   

  constructor(private _http: Http) { }  

  createAuthorizationHeader(headers: Headers) {
    headers.append('Content-Type', 'application/json');
    const token = localStorage.getItem('auth_token');
    if (token) {
      headers.append(AUTH_HEADER_KEY, `${AUTH_PREFIX} ${token}`);
    }    
  }

  protected handleError(error: any) {
    var applicationError = error.headers.get('Application-Error');

    // either applicationError in header or model error in body
    if (applicationError) {
      return Observable.throw(applicationError);
    }

    var modelStateErrors: string = '';
    var serverError = error.json();

    if (!serverError.type) {
      for (var key in serverError) {
        if (serverError[key])
          modelStateErrors += serverError[key] + '\n';
      }
    }

    modelStateErrors = modelStateErrors = '' ? null : modelStateErrors;
    return Observable.throw(modelStateErrors || 'Server error');
  }

  protected api_get(url) {
    let headers = new Headers();
    this.createAuthorizationHeader(headers);
    return this._http.get(url, {headers: headers});
  }


  protected api_post(url, data) {
    let headers = new Headers();
    this.createAuthorizationHeader(headers);
    return this._http.post(url, data, {
      headers: headers
    });
  }
}
