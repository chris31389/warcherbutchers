import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { SharedModule } from "../shared";

import {
    CategoryService,
    ProductService,
    BasketService
    } from "./";

import {
    StoreComponent,
    BasketComponent,
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
        BasketService,
        CategoryService,
        ProductService
    ],
    declarations: [
        StoreComponent,
        BasketComponent,
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