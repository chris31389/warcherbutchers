import {ProductSelection, Product, BasketService} from "./";
import { Price } from "../../../";

export class Basket {
    items: Array<ProductSelection>;
    subTotalCost = new Price();
    totalCost = new Price();
    deliveryLimit = new Price({ major: 75, minor: 0 });
    deliveryPriceApplied = new Price();
    private saveItems: (selection: Array<ProductSelection>) => void;

    get totalItems() { return this.items.length; };

    constructor(
        items: Array<ProductSelection>,
        update: (selection: Array<ProductSelection>) => void
    ) {
        this.items = items;
        this.saveItems = update;
    }

    removeAllItems = () => {
        this.items.splice(0, this.items.length);
        this.saveItems(this.items);
    };

    add = (product: Product) => {
        const productSelectionFound = this.items.find(x => x.product.id === product.id);
        if (productSelectionFound) {
            productSelectionFound.quantity++;
        } else {
            this.items.push(new ProductSelection(product));
        }
        this.saveItems(this.items);
    }

    remove = (product: Product) => {
        const productSelectionFound = this.items.find(x => x.product.id === product.id);
        if (productSelectionFound) {
            if (productSelectionFound.quantity > 1) {
                productSelectionFound.quantity--;
                this.saveItems(this.items);
            } else {
                this.removeItem(productSelectionFound);
            }
        }
    }

    removeItem = (productSelection: ProductSelection) => {
        const productSelectionFoundIndex = this.items.findIndex(x => x.product.id === productSelection.product.id);
        this.items.splice(productSelectionFoundIndex, 1);
        this.saveItems(this.items);
    }
}