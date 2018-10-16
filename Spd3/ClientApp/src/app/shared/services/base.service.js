"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var Rx_1 = require("rxjs/Rx");
var http_1 = require("@angular/http");
var AUTH_HEADER_KEY = 'Authorization';
var AUTH_PREFIX = 'Bearer';
var BaseService = /** @class */ (function () {
    function BaseService(_http) {
        this._http = _http;
    }
    BaseService.prototype.createAuthorizationHeader = function (headers) {
        headers.append('Content-Type', 'application/json');
        var token = localStorage.getItem('auth_token');
        if (token) {
            headers.append(AUTH_HEADER_KEY, AUTH_PREFIX + " " + token);
        }
    };
    BaseService.prototype.handleError = function (error) {
        var applicationError = error.headers.get('Application-Error');
        // either applicationError in header or model error in body
        if (applicationError) {
            return Rx_1.Observable.throw(applicationError);
        }
        var modelStateErrors = '';
        var serverError = error.json();
        if (!serverError.type) {
            for (var key in serverError) {
                if (serverError[key])
                    modelStateErrors += serverError[key] + '\n';
            }
        }
        modelStateErrors = modelStateErrors = '' ? null : modelStateErrors;
        return Rx_1.Observable.throw(modelStateErrors || 'Server error');
    };
    BaseService.prototype.api_get = function (url) {
        var headers = new http_1.Headers();
        this.createAuthorizationHeader(headers);
        return this._http.get(url, { headers: headers });
    };
    BaseService.prototype.api_post = function (url, data) {
        var headers = new http_1.Headers();
        this.createAuthorizationHeader(headers);
        return this._http.post(url, data, {
            headers: headers
        });
    };
    return BaseService;
}());
exports.BaseService = BaseService;
//# sourceMappingURL=base.service.js.map