import { Component, Input, Output, EventEmitter } from "@angular/core";

@Component({
    selector: "product",
    templateUrl: "./product.component.html",
    styleUrls: [ "./product.component.css" ]
})
export class ProductComponent {
    @Input()
    item: any;

    @Output()
    addToBasket = new EventEmitter<any>();

    add = this.addToBasket.emit(this.item);
}
