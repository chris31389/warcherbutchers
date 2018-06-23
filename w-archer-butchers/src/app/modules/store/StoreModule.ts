import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { SharedModule } from "../shared";

import {
    CategoryService,
    ProductService,
    OrderService,
    BasketService
    } from "./";

import {
    CheckoutComponent,
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
            { path: "checkout", component: CheckoutComponent },
            { path: "speciality-products", component: SpecialityProductsComponent }
        ])
    ],
    providers: [
        CategoryService,
        ProductService,
        OrderService,
        BasketService
    ],
    declarations: [
        StoreComponent,
        CheckoutComponent,
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