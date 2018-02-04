import { Component, Input } from "@angular/core";
import {
    FormElement,
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
    paymentSenseUrl = "https://mms.paymentsensegateway.com/Pages/PublicPages/PaymentForm.aspx";
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
        this.orderService
            .submitOrder(this.customerData, this.basket.items)
            .subscribe(formElements => {
                console.log(formElements);
                this.createFormAndSubmit(formElements);
            });
    };

    createFormAndSubmit = (formElements: Array<FormElement>) => {

        var myForm = document.createElement("FORM") as HTMLFormElement;

        myForm.name = "myForm";
        myForm.method = "POST";
        myForm.action = this.paymentSenseUrl;

        formElements.forEach(element => {
            // var value = element.value !== undefined ? element.value : "";
            var myInput = document.createElement("INPUT") as HTMLFormElement;
            myInput.type = "HIDDEN";
            myInput.name = element.key;
            myInput.value = element.value;
            myForm.appendChild(myInput);
        });

        document.body.appendChild(myForm);
        myForm.submit();

    }
}