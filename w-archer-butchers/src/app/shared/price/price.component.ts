import { Component, Input } from "@angular/core";
import { Price } from "./price";

@Component({
    selector: "app-price",
    templateUrl: "./price.component.html",
    styleUrls: ["./price.component.scss"]
})
export class PriceComponent {
    @Input() value: Price;
    @Input() highlight: boolean;
    @Input() strike: boolean;
}
