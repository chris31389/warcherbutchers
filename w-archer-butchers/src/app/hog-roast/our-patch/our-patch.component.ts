import { Component } from "@angular/core";
import { DomSanitizer } from "@angular/platform-browser";

@Component({
    selector: "app-our-patch",
    templateUrl: "./our-patch.component.html",
    styleUrls: [ "./our-patch.component.scss" ]
})
export class OurPatchComponent {
    caption = "We're located near the heart of Leicester and supply Hog Roasts to the entire Leicestershire area.";
    instruction = "Contact us directly on";
    telephoneNumber = "0116 270 7876";
    emailAddress = "sales@warcherbutchers.co.uk";
    mapUrl = "https://www.google.com/maps/embed/v1/place?q=leicestershire%20county&key=AIzaSyB1Dmd67UqYsci_eiiOYOtN88kKRh7syOg";

    constructor(public sanitizer: DomSanitizer) { }

    getMapUrl = () =>  this.sanitizer.bypassSecurityTrustResourceUrl(this.mapUrl);
}
