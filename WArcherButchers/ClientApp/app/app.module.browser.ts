import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { CommonModule } from "@angular/common";
import { FormsModule } from "@angular/forms";
import { HttpModule } from "@angular/http";
import { NgxPageScrollModule } from "ngx-page-scroll";

import {
    CoreModule,
    SharedModule,
    HomeModule,
    StoreModule,
    ButcheryClassesModule,
    HogRoastModule,
    OtherModule
    } from "./modules";

import { AppRoutingModule } from "./app-routing.module";

import {
    AppComponent,
    NavMenuComponent,
    CallbackComponent,
    AppFooterComponent
    } from "./components";

@NgModule({
    bootstrap: [AppComponent],
    declarations: [
        AppComponent,
        CallbackComponent,
        NavMenuComponent,
        AppFooterComponent
    ],
    imports: [
        BrowserModule,
        CommonModule,
        HttpModule,
        FormsModule,
        CoreModule,
        SharedModule,
        StoreModule,
        HomeModule,
        ButcheryClassesModule,
        HogRoastModule,
        OtherModule,
        AppRoutingModule,
        NgxPageScrollModule
    ],
    providers: [
        { provide: "BASE_URL", useFactory: getBaseUrl }
    ]
})
export class AppModule {
}

export function getBaseUrl() {
    return document.getElementsByTagName("base")[0].href;
}