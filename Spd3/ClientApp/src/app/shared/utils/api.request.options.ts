import { BaseRequestOptions } from '@angular/http';

export class ApiRequestOptions extends BaseRequestOptions {

  constructor() {
    super();
    this.headers.append('Content-Type', 'application/json');    
  }

}
