import { Component, OnInit } from "@angular/core";
import { StoreSnippetService } from "./store-snippet.service";
import { Product } from "src/app/shared/product/product";

@Component({
    selector: "app-store-snippet",
    templateUrl: "./store-snippet.component.html",
    styleUrls: ["./store-snippet.component.scss"]
})
export class StoreSnippetComponent implements OnInit {
    ngOnInit(): void {
        this.storeSnippetService.randomProduct.subscribe(x => this.product = x);
    }
    product: Product;
    storeInfo = {
        message: "There are many more products available for purchase.  Find out more by visiting our store.",
        linkMessage: "The Store"
    }

    constructor(private readonly storeSnippetService: StoreSnippetService) {
    }
}