import { Component, Input } from "@angular/core";
import { Price } from "../../";

@Component({
    selector: "price",
    templateUrl: "./price.component.html",
    styleUrls: [ "./price.component.css" ]
})
export class PriceComponent {
    @Input()
    value: Price;

    @Input()
    highlight: boolean;
}
