﻿import {
    NgModule,
    Optional,
    SkipSelf
    } from "@angular/core";

import { AuthHttp } from "angular2-jwt";
import { CommonModule } from "@angular/common";
import { Http, RequestOptions } from "@angular/http";

import {
    ErrorService,
    ReferenceDataService,
    DownloadService,
    AuthService,
    AuthConfig,
    ServerSettings,
    Auth0Factory
    } from "./";

declare var server: ServerSettings;
declare var auth0Configuration: AuthConfig;

@NgModule({
    imports: [CommonModule],
    declarations: [],
    exports: [],
    providers: [
        DownloadService,
        ErrorService,
        ReferenceDataService,
        { provide: "Auth0Config", useValue: auth0Configuration },
        AuthService,
        {
            provide: AuthHttp,
            useFactory: Auth0Factory.authHttpServiceFactory,
            deps: [Http, RequestOptions]
        },
        { provide: "ORIGIN_URL", useValue: location.origin + "/" },
        { provide: "SERVER_URL", useValue: server.url + "/" }
    ]
})
export class CoreModule {
    constructor(@Optional() @SkipSelf() parentModule: CoreModule) {
        if (parentModule) {
            throw new Error(
                "CoreModule is already loaded. Import it in the AppModule only");
        }
    }
}