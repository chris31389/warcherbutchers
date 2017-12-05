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
    SpecialityProductsModule,
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
        HomeModule,
        StoreModule,
        ButcheryClassesModule,
        HogRoastModule,
        SpecialityProductsModule,
        OtherModule,
        AppRoutingModule,
        NgxPageScrollModule
    ],
    providers: [
        { provide: "BASE_URL", useFactory: getBaseUrl }
    ]
} as any)
export class AppModule {
}

export function getBaseUrl() {
    return document.getElementsByTagName("base")[0].href;
}