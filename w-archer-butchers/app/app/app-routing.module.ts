import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { CallbackComponent } from "./components"

export const routes: Routes = [
    { path: "callback", component: CallbackComponent },
    { path: "**", redirectTo: "home" }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }