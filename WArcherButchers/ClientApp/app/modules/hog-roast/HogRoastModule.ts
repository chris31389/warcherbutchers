import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { SharedModule } from "./../shared";

import {
    HogRoastComponent,
    OurPatchComponent,
    BossMessageComponent,
    StoryComponent
    } from "./components";

@NgModule({
    imports: [
        SharedModule,
        RouterModule.forChild([
            { path: "hog-roast", component: HogRoastComponent }
        ])
    ],
    providers: [],
    declarations: [
        HogRoastComponent,
        OurPatchComponent,
        BossMessageComponent,
        StoryComponent
    ],
    exports: [RouterModule]
})
export class HogRoastModule {
}