import { Component } from "@angular/core";
import { Basket, BasketService, Product, ProductService} from "../../";

@Component({
    selector: "speciality-products",
    templateUrl: "./speciality-products.component.html",
    styleUrls: ["./speciality-products.component.css"]
})
export class SpecialityProductsComponent {
    basket:Basket;
    specialityProducts: Array<Product>;
    
    splash = {
        title: "Speciality Products",
        adjective: "Unique",
        caption: "Something special you won't find elsewhere"
    }

    constructor(
        private readonly basketService: BasketService,
        private readonly productService: ProductService) {
        this.productService.getSpecialityProducts()
            .subscribe(products => this.specialityProducts = products);

        this.basket = this.basketService.basket;
    }

    addToBasket = (product: Product) => { };
}