import { Component, OnInit } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';

@Component({
    selector: 'app-contact-us',
    templateUrl: './contact-us.component.html',
    styleUrls: ['./contact-us.component.scss']
})
export class ContactUsComponent {
    caption = "We're located near the heart of Leicester and supply top quality meat to the surrounding area.";
    instruction = "Contact us directly on";
    telephoneNumber = "0116 270 7876";
    emailAddress = "sales@warcherbutchers.co.uk";
    mapUrl = "https://www.google.com/maps/embed/v1/place?q=99%20LE2%201TT&key=AIzaSyB1Dmd67UqYsci_eiiOYOtN88kKRh7syOg";

    constructor(public sanitizer: DomSanitizer) { }

    getMapUrl = () => this.sanitizer.bypassSecurityTrustResourceUrl(this.mapUrl);
}
