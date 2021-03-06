﻿import { Component } from "@angular/core";
import {
    Product,
    Basket,
    CategoryService,
    ProductService,
    BasketService
    } from "../../";

@Component({
    selector: "store",
    templateUrl: "./store.component.html",
    styleUrls: ["./store.component.css"]
})
export class StoreComponent {
    basket: Basket;
    searchTerm: string = "";
    categories: Array<string> = [];
    filteredProducts: Array<Product>;
    products: Array<Product>;

    constructor(
        private readonly basketService: BasketService,
        private readonly categoryService: CategoryService,
        private readonly productService: ProductService,
    ) {
        this.categories = categoryService.categories;
        this.filteredProducts = new Array<Product>();
        this.productService.getProducts()
            .subscribe(products => {
                this.products = products;
                this.products.forEach(product => this.filteredProducts.push(product));
            });
        this.basket = this.basketService.basket;
    }

    updateFilterItems = () => {}
    includeCategory = (category: any) => {}

    addToBasket = (product: Product) => this.basket.add(product);
}