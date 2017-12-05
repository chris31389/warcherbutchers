import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { SharedModule } from "../shared";

import {
    CategoryService
    } from "./";

import {
    StoreComponent,
    SidebarComponent,
    ProductComponent
    } from "./components";

@NgModule({
    imports: [
        SharedModule,
        RouterModule.forChild([
            { path: "store", component: StoreComponent }
        ])
    ],
    providers: [
        CategoryService
    ],
    declarations: [
        StoreComponent,
        SidebarComponent,
        ProductComponent
    ],
    exports: [
        RouterModule,
        ProductComponent
    ]
} as any)
export class StoreModule {
}