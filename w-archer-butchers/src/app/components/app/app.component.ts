import "jquery";
import "bootstrap";
import { Component, ViewChild } from "@angular/core";
import { Error, ErrorService } from "../../modules/core";

@Component({
    selector: "app", 
    templateUrl: "./app.component.html",
    styleUrls: ["./app.component.css"]
})
export class AppComponent {
    error: Error;
    @ViewChild("errorModal")
    errorModal;

    modalHide() {
        this.errorModal.hide();
        this.error = undefined;
    }

    constructor(private readonly errorService: ErrorService) {}

    ngOnInit() {
        this.errorService.listen((error: Error) => {
            this.error = error;
            this.errorModal.show();
        });
    }
}