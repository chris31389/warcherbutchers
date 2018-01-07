import { Product, Basket } from "../../";
import { Component } from "@angular/core";
import { CategoryService, ProductService } from "../../";

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

    constructor(
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
        this.basket = new Basket();
    }

    updateFilterItems = () => {}
    includeCategory = (category: any) => {}

    products: Array<Product>;
    
    addToBasket = (product: Product) => {};
}