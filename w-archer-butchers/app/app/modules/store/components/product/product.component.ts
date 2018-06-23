import { Component, Input, Output, EventEmitter } from "@angular/core";
import { Product } from "../../";

@Component({
    selector: "product",
    templateUrl: "./product.component.html",
    styleUrls: ["./product.component.css"]
})
export class ProductComponent {
    @Input()
    product: Product;

    @Output()
    addToBasket = new EventEmitter<Product>();

    private isAddToBasketUsed = false;

    ngOnInit() {
        this.isAddToBasketUsed = this.addToBasket.observers.length > 0;
    }

    addItem = () => this.addToBasket.emit(this.product);
}