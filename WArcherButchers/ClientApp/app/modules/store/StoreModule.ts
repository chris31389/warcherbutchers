import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { SharedModule } from "../shared";

import {
    CategoryService,
    ProductService
    } from "./";

import {
    StoreComponent,
    SidebarComponent,
    ProductComponent,
    SpecialityProductComponent,
    SpecialityProductsComponent
    } from "./components";

@NgModule({
    imports: [
        SharedModule,
        RouterModule.forChild([
            { path: "store", component: StoreComponent },
            { path: "speciality-products", component: SpecialityProductsComponent }
        ])
    ],
    providers: [
        CategoryService,
        ProductService
    ],
    declarations: [
        StoreComponent,
        SidebarComponent,
        ProductComponent,
        SpecialityProductComponent,
        SpecialityProductsComponent
    ],
    exports: [
        RouterModule,
        ProductComponent
    ]
})
export class StoreModule {
}