import { Component } from "@angular/core";
import { Product, ProductService } from "../../../store";

@Component({
    selector: "store-snippet",
    templateUrl: "./store-snippet.component.html",
    styleUrls: ["./store-snippet.component.css"]
})
export class StoreSnippetComponent {
    product: Product;
    storeInfo = {
        message: "There are many more products available for purchase.  Find out more by visiting our store.",
        linkMessage: "The Store"
    }

    constructor(private readonly productService: ProductService) {
        this.productService.getRandomProduct()
            .subscribe(x => this.product = x);
    }
}