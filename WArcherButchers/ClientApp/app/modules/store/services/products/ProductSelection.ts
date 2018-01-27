import { Product } from "./";
import { Price } from "../../../";

export class ProductSelection {
    product: Product;
    quantity: number;

    constructor(product: Product, quantity?: number) {
        this.product = product;
        this.quantity = quantity ? quantity : 1;
    }

    get totalCost(): Price { return this.product.price.multiplyBy(this.quantity); }
}