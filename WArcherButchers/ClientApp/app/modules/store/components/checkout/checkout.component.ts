import { Component, Input } from "@angular/core";
import {
    Product,
    CustomerData,
    Basket,
    CategoryService,
    ProductService,
    BasketService
    } from "../../";


@Component({
    selector: "checkout",
    templateUrl: "./checkout.component.html",
    styleUrls: [ "./checkout.component.css" ]
})
export class CheckoutComponent {
    basket: Basket;
    customerData = new CustomerData();
    title = "Checkout";
    yourDetails = "Your Details";
    payBtn = "Continue to Payment";
    constructor(
        private readonly basketService: BasketService,
        private readonly categoryService: CategoryService,
        private readonly productService: ProductService,
    ) {
        this.basket = this.basketService.basket;
    }

    submitForm = () => { console.log(this.customerData)};
}