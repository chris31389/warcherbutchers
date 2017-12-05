import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { SharedModule } from "./../shared";

import {
    TermsAndConditionsComponent,
    } from "./components";

@NgModule({
    imports: [
        SharedModule,
        RouterModule.forChild([
            { path: "terms", component: TermsAndConditionsComponent }
        ])
    ],
    providers: [],
    declarations: [
        TermsAndConditionsComponent
    ],
    exports: [RouterModule]
} as any)
export class OtherModule {
}