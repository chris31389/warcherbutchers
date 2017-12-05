import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { SharedModule } from "../shared";
import { StoreModule } from "../store";

import {
    HomeComponent,
    ChristmasOrdersComponent,
    StoreSnippetComponent,
    GangComponent,
    HogComponent
    } from "./components";

@NgModule({
    imports: [
        SharedModule,
        StoreModule,
        RouterModule.forChild([
            { path: "home", component: HomeComponent }
        ])
    ],
    providers: [],
    declarations: [
        HomeComponent,
        StoreSnippetComponent,
        ChristmasOrdersComponent,
        GangComponent,
        HogComponent
    ],
    exports: [RouterModule]
} as any)
export class HomeModule {
}