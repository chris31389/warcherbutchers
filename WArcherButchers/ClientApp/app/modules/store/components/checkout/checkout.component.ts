import { Component, Input } from "@angular/core";
import {
    Product,
    CustomerData,
    Basket,
    CategoryService,
    ProductService,
    BasketService,
    OrderService
    } from "../../";


@Component({
    selector: "checkout",
    templateUrl: "./checkout.component.html",
    styleUrls: ["./checkout.component.css"]
})
export class CheckoutComponent {
    basket: Basket;
    customerData = new CustomerData();
    title = "Checkout";
    yourDetails = "Your Details";
    payBtn = "Continue to Payment";
    submitClicked = false;

    constructor(
        private readonly basketService: BasketService,
        private readonly categoryService: CategoryService,
        private readonly productService: ProductService,
        private readonly orderService: OrderService
    ) {
        this.basket = this.basketService.basket;
    }

    submitForm = () => {
        this.submitClicked = true;
        this.orderService.submitOrder(this.customerData, this.basket.items);
    };
}