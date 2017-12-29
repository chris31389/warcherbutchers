import {ProductSelection} from "./";
import { Price } from "../../../";

export class Basket {
    items: Array<ProductSelection>;
    totalItems: number;
    subTotalCost = new Price();
    totalCost = new Price();
    deliveryLimit = new Price({ major: 75, minor: 0 });
    deliveryPriceApplied = new Price();

    constructor() {
        this.items = new Array<ProductSelection>();
        this.totalItems = 0;
    }

    removeAllItems = () => this.items.splice(0, this.items.length);

}