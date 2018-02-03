// import {  } from "./";

import { ProductSelection } from "../";

export class OrderService {
    private updateStorage(selection: Array<ProductSelection>): void {
        const mappedSelection = selection.map(productSelection => {
            return {
                productId: productSelection.product.id,
                quantity: productSelection.quantity
            }
        });

        const json = JSON.stringify(mappedSelection);
        localStorage.setItem("basketItems", json);
    }
}