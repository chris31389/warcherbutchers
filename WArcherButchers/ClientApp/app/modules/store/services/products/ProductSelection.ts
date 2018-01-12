import { Product } from "./";

export class ProductSelection {
    product: Product;
    quantity: number;

    constructor(product: Product, quantity?: number) {
        this.product = product;
        this.quantity = quantity ? quantity : 1;
    }
}