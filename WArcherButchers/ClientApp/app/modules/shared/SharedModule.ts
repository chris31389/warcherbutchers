import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { CommonModule } from "@angular/common";
import { FormsModule } from "@angular/forms";

import {
    AppModalComponent,
    SplashBannerComponent,
    ScriptHackComponent,
    ContactUsComponent
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
        ContactUsComponent
    ],
    exports: [
        CommonModule,
        FormsModule,
        AppModalComponent,
        SplashBannerComponent,
        ScriptHackComponent,
        ContactUsComponent
    ],
    providers: [
    ]
})
export class SharedModule {
}