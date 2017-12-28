import {Price, ProductSelection} from "./";

export class Basket {
    items: Array<ProductSelection>;
    totalItems: number;
    subTotalCost: Price;
    totalCost: Price;

    constructor() {
        this.items = new Array<ProductSelection>();
        this.totalItems = 0;
    }

    removeAllItems = () => this.items.splice(0, this.items.length);
}