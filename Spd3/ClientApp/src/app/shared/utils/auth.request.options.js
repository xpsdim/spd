"use strict";
var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
        return extendStatics(d, b);
    }
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
Object.defineProperty(exports, "__esModule", { value: true });
var http_1 = require("@angular/http");
var AUTH_HEADER_KEY = 'Authorization';
var AUTH_PREFIX = 'Bearer';
var AuthRequestOptions = /** @class */ (function (_super) {
    __extends(AuthRequestOptions, _super);
    function AuthRequestOptions() {
        var _this = _super.call(this) || this;
        _this.headers.append('Content-Type', 'application/json');
        var token = localStorage.getItem('auth_token');
        if (token) {
            _this.headers.append(AUTH_HEADER_KEY, AUTH_PREFIX + " " + token);
        }
        return _this;
    }
    return AuthRequestOptions;
}(http_1.BaseRequestOptions));
exports.AuthRequestOptions = AuthRequestOptions;
//# sourceMappingURL=auth.request.options.js.map