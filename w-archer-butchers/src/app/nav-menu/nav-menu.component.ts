import { Component } from "@angular/core";

@Component({
    selector: "app-nav-menu",
    templateUrl: "./nav-menu.component.html",
    styleUrls: ["./nav-menu.component.scss"]
})
export class NavMenuComponent {
    /*     constructor(public auth: AuthService) {
            auth.handleAuthentication();
            auth.scheduleRenewal();
        } */

    get isAuthenticated(): boolean { return false; }
}
