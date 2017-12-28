﻿import { Component, Input, Output, EventEmitter } from "@angular/core";
import {Product} from "../../";

@Component({
    selector: "product",
    templateUrl: "./product.component.html",
    styleUrls: [ "./product.component.css" ]
})
export class ProductComponent {
    @Input()
    product: Product;

    @Output()
    addToBasket = new EventEmitter<any>();

    add = this.addToBasket.emit(this.product);
}
