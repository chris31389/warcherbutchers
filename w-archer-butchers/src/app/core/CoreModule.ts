import {
    NgModule,
    Optional,
    SkipSelf
} from "@angular/core";


import { HttpClientModule } from "@angular/common/http";
// import { AuthHttp, AuthConfig } from "angular2-jwt";
import { CommonModule } from "@angular/common";
import { Http, RequestOptions } from "@angular/http";
import { ServerSettings } from "./ServerSettings";
import { ClientSettings } from "./ClientSettings";
import { DownloadService } from "./DownloadService";
import { ReferenceDataService } from "./references/ReferenceDataService";
// import { AuthService } from "./auth/AuthService";
// import { Auth0Factory } from "./Auth0Factory";

declare var server: ServerSettings;
declare var client: ClientSettings;
// declare var auth0Configuration: AuthConfig;

@NgModule({
    imports: [CommonModule, HttpClientModule],
    declarations: [],
    exports: [],
    providers: [
        DownloadService,
        ReferenceDataService,
//        { provide: "Auth0Config", useValue: auth0Configuration },
//        AuthService,
/*         {
            provide: AuthHttp,
            useFactory: Auth0Factory.authHttpServiceFactory,
            deps: [Http, RequestOptions]
        },
 */        { provide: "ORIGIN_URL", useValue: location.origin },
        { provide: "SERVER_URL", useValue: server.url },
        { provide: "CLIENT_URL", useValue: client.url }
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