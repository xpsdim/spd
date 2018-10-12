import { BaseRequestOptions } from '@angular/http';

const AUTH_HEADER_KEY = 'Authorization';
const AUTH_PREFIX = 'Bearer';

export class AuthRequestOptions extends BaseRequestOptions {

  constructor() {
    super();

    this.headers.append('Content-Type', 'application/json');
    const token = localStorage.getItem('auth_token');    
    if (token) {
      this.headers.append(AUTH_HEADER_KEY, `${AUTH_PREFIX} ${token}`);
    }
  }

}
