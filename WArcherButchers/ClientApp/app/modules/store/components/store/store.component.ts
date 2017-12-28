import { Product } from "../../";
import { Component } from "@angular/core";
import { CategoryService } from "../../";

@Component({
    selector: "store",
    templateUrl: "./store.component.html",
    styleUrls: ["./store.component.css"]
})
export class StoreComponent {
    basket
    searchTerm: string = "";
    categories: Array<string> = [];
    filteredProducts: Array<Product>;

    constructor(private categoryService: CategoryService) {
        this.categories = categoryService.getOptions();
        this.products = new Array<Product>();
        this.products.push(new Product({
            name: "Biltong",
            description: "Description",
            detailedDescription: "Detailed Description"
        }));

        this.filteredProducts = new Array<Product>();
        this.products.forEach(product => this.filteredProducts.push(product));
    }

    updateFilterItems = () => {}
    includeCategory = (category: any) => {}

    products: Array<Product>;
    
    addToBasket = (product: Product) => {};
}