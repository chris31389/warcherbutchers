import { Component } from "@angular/core";

@Component({
    selector: "on-offer",
    templateUrl: "./on-offer.component.html",
    styleUrls: [ "./on-offer.component.css" ]
})
export class OnOfferComponent {
    classes: Array<any> = [];

    noClassElement = {
        imageUrl: "../media/classes/sausage-class.jpg",
        name: "Contact us directly for the latest information",
        caption: "Please contact us directly if you are interested in learning butchery classes and we can keep you up to date when classes to become available."
    };
}
