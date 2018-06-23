import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { ButcheryClassesComponent } from "./butchery-classes/butchery-classes.component";
import { OnOfferComponent } from "./on-offer/on-offer.component";
import { SharedModule } from "../shared/shared.module";
import { CommonModule } from "@angular/common";

@NgModule({
    imports: [
        CommonModule,
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