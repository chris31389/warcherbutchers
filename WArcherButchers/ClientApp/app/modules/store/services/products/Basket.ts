import {ProductSelection, Product, DeliveryInfo} from "./";
import { Price } from "../../../";

export class Basket {
    items: Array<ProductSelection>;
    private saveItems: (selection: Array<ProductSelection>) => void;
    private deliveryInfo: DeliveryInfo;

    get subTotalCost(): Price {
        let price = new Price();

        this.items.forEach(selectedProduct =>
            price = price.add(selectedProduct.product.price.multiplyBy(selectedProduct.quantity)));

        return price;
    }

    get totalCost(): Price { return this.subTotalCost.add(this.deliveryPriceApplied); }

    get totalItems() { return this.items.length; }

    get deliveryPriceApplied(): Price {
        return this.subTotalCost.lessThan(this.deliveryInfo.limit)
            ? this.deliveryInfo.cost
            : new Price();
    }

    constructor(
        items: Array<ProductSelection>,
        deliveryInfo: DeliveryInfo,
        update: (selection: Array<ProductSelection>) => void
    ) {
        this.items = items;
        this.deliveryInfo = deliveryInfo;
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