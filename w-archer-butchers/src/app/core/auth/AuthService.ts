/* import { Injectable, Inject, EventEmitter } from "@angular/core";
// import { AuthHttp } from "angular2-jwt";
import { Response } from "@angular/http";
import { Router } from "@angular/router";
import { Observable, timer, of } from "rxjs";
import { mergeMap } from "rxjs/operators";
import AuthConfig = require("./AuthConfig");
import * as auth0 from 'auth0-js';

@Injectable()
export class AuthService {
    private url = "api/v1/users/me";
    private refreshSubscription: any;
    private auth0: any;

    userProfile: any;
    rolesUpdated = new EventEmitter<Array<number>>();

    constructor(
        public router: Router,
        @Inject("Auth0Config") private authConfig: AuthConfig.AuthConfig,
        private authHttp: AuthHttp,
        @Inject("SERVER_URL") private approvalsUrl: string
    ) {
        this.auth0 = new auth0.WebAuth({
            clientID: authConfig.clientId,
            domain: authConfig.domain,
            responseType: "token id_token",
            audience: authConfig.apiUrl,
            redirectUri: authConfig.callbackUrl,
            scope: "openid email profile"
        });
    }

    login = (): void => this.auth0.authorize();

    getRoles(): Observable<Array<number>> {
        return this.authHttp.get(this.approvalsUrl + this.url)
            .map((response: Response) => {
                return response.json().roles as Array<number>;
            })
            .catch(this.handleError);
    }

    handleAuthentication(): void {
        this.auth0.parseHash((err, authResult) => {
            if (authResult && authResult.accessToken && authResult.idToken) {
                window.location.hash = "";
                this.setSession(authResult);
                this.router.navigate(["/approvals"]);
            } else if (err) {
                this.router.navigate(["/home"]);
                console.log(err);
            }
        });
    }

    getProfile(cb): void {
        const accessToken = localStorage.getItem("access_token");
        if (!accessToken) {
            throw new Error("Access token must exist to fetch profile");
        }

        const self = this;
        this.auth0.client.userInfo(accessToken,
            (err, profile) => {
                if (profile) {
                    self.userProfile = profile;
                }
                cb(err, profile);
            });
    }

    logout(): void {
        // Remove tokens and expiry time from localStorage
        localStorage.removeItem("access_token");
        localStorage.removeItem("id_token");
        localStorage.removeItem("expires_at");
        this.rolesUpdated.emit(new Array<number>());
        this.unscheduleRenewal();
        // Go back to the home route
        this.router.navigate(["/"]);
    }

    isAuthenticated(): boolean {
        // Check whether the current time is past the
        // access token's expiry time
        const expiresAt = JSON.parse(localStorage.getItem("expires_at"));
        return Date.now() < expiresAt;
    }

    renewToken() {
        this.auth0.renewAuth({
            audience: this.authConfig.apiUrl,
            redirectUri: this.authConfig.silentUrl,
            usePostMessage: true
        },
            (err, result) => {
                if (err) {
                    console.log(`Could not get a new token using silent authentication (${err.error}).`);
                    this.logout();
                } else {
                    console.log(`Successfully renewed auth!`);
                    this.setSession(result);
                    this.getRoles()
                        .subscribe(
                            roles => this.rolesUpdated.emit(roles)
                        );
                }
            });
    }

    scheduleRenewal() {
        if (!this.isAuthenticated()) return;
        this.unscheduleRenewal();

        const expiresAt = JSON.parse(window.localStorage.getItem("expires_at"));

        const source = of(expiresAt).pipe(mergeMap(
            (expiresAtValue: number): Observable<number> => {

                const now = Date.now();

                // Use the delay in a timer to
                // run the refresh at the proper time
                return timer(Math.max(1, expiresAtValue - now));
            }));

        // Once the delay time from above is
        // reached, get a new JWT and schedule
        // additional refreshes
        this.refreshSubscription = source.subscribe(() => {
            this.renewToken();
            this.scheduleRenewal();
        });
    }

    unscheduleRenewal() {
        if (!this.refreshSubscription) return;
        this.refreshSubscription.unsubscribe();
    }

    private getPayload(token): any {
        if (token.indexOf(".") < 0) {
            return "{}";
        }

        const base64Url = token.split(".")[1];
        const base64 = base64Url.replace("-", "+").replace("_", "/");
        const json = JSON.parse(window.atob(base64));
        return json;
    }

    private setSession(authResult): void {
        // Set the time that the access token will expire at
        const expiresAt = JSON.stringify((authResult.expiresIn * 1000) + Date.now());

        localStorage.setItem("access_token", authResult.accessToken);
        localStorage.setItem("id_token", authResult.idToken);
        localStorage.setItem("expires_at", expiresAt);

        this.scheduleRenewal();
    }

    private isArray(argument) {
        return Array.isArray
            ? Array.isArray(argument)
            : argument instanceof Object
                ? argument instanceof Array
                : Object.prototype.toString.call(argument) === "[object Array]";
    }

    private handleError = (response: Response) => { } //this.errorService.handleHttpResponseError(response, "Auth Error");
} */
