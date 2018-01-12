import { Basket, ProductSelection, ProductService } from "./";

export class BasketService {
    basket = null;

    constructor(
    ) {
        const productService = new ProductService();
        const basketItems = new Array<ProductSelection>()

        const foundItems = localStorage.getItem("basketItems");
        if (foundItems) {
            const json = JSON.parse(foundItems);
            if (json && Array.isArray(json)) {
                productService.getProducts()
                    .subscribe(products => {
                        json.forEach(jsonElement => {
                            const product = products.find(x => x.id === jsonElement.productId);
                            if (product) {
                                basketItems.push(new ProductSelection(product, jsonElement.quantity));
                            }
                        });
                    });
            }
        }

        this.basket = new Basket(basketItems, this.updateStorage);
    }

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