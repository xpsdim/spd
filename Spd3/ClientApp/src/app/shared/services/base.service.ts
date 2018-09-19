import { Observable } from 'rxjs/Rx';
import { Headers } from '@angular/http';

export abstract class BaseService {   

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

  protected jsonContentTypeHeader() {
    let _jsonContentTypeHeader = new Headers();
    _jsonContentTypeHeader.append('Content-Type', 'application/json');
    return _jsonContentTypeHeader;
  }
}
