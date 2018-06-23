import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { CommonModule } from "@angular/common";
import { FormsModule } from "@angular/forms";

import {
    AppModalComponent,
    SplashBannerComponent,
    ScriptHackComponent,
    ContactUsComponent,
    PriceComponent
    } from "./components";

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        RouterModule
    ],
    declarations: [
        AppModalComponent,
        SplashBannerComponent,
        ScriptHackComponent,
        ContactUsComponent,
        PriceComponent
    ],
    exports: [
        CommonModule,
        FormsModule,
        AppModalComponent,
        SplashBannerComponent,
        ScriptHackComponent,
        ContactUsComponent,
        PriceComponent
    ],
    providers: [
    ]
})
export class SharedModule {
}