import { Http, RequestOptions } from "@angular/http";
import { AuthHttp, AuthConfig } from "angular2-jwt";

export class Auth0Factory {
    static authHttpServiceFactory(http: Http, options: RequestOptions) {
        return new AuthHttp(new AuthConfig({
                tokenGetter: (() => localStorage.getItem("access_token")),
                globalHeaders: [{ 'Content-Type': "application/json" }],
            }),
            http,
            options);
    }
}