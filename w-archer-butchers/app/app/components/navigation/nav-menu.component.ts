import { Component } from "@angular/core";
import { AuthService } from "./../../modules/core";

@Component({
    selector: "nav-menu",
    templateUrl: "./nav-menu.component.html",
    styleUrls: ["./nav-menu.component.css"]
})
export class NavMenuComponent {
    constructor(public auth: AuthService) {
        auth.handleAuthentication();
        auth.scheduleRenewal();
    }
}
