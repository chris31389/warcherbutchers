import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { SharedModule } from "./../shared";

import {
    SpecialityProductsComponent,
    } from "./components";

@NgModule({
    imports: [
        SharedModule,
        RouterModule.forChild([
            { path: "speciality-products", component: SpecialityProductsComponent }
        ])
    ],
    providers: [],
    declarations: [
        SpecialityProductsComponent
    ],
    exports: [RouterModule]
} as any)
export class SpecialityProductsModule {
}