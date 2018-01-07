import { Component, Input, Output, EventEmitter } from "@angular/core";
import { Product} from "../../";

@Component({
    selector: "speciality-product",
    templateUrl: "./speciality-product.component.html",
    styleUrls: ["./speciality-product.component.css"]
})
export class SpecialityProductComponent {
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