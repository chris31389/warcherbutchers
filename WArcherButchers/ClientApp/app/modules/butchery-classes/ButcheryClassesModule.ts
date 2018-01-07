import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { SharedModule } from "./../shared";

import {
    ButcheryClassesComponent,
    OnOfferComponent
    } from "./components";

@NgModule({
    imports: [
        SharedModule,
        RouterModule.forChild([
            { path: "butchery-classes", component: ButcheryClassesComponent }
        ])
    ],
    providers: [],
    declarations: [
        ButcheryClassesComponent,
        OnOfferComponent
    ],
    exports: [RouterModule]
})
export class ButcheryClassesModule {
}