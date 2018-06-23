import { Injectable, Inject } from "@angular/core";
import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { Observable } from "rxjs/Rx";

import { ProductSelection, CustomerData } from "../";
import { OrderProduct, FormElement } from "./";

@Injectable()
export class OrderService {
    constructor(
        private readonly http: HttpClient,
        @Inject("SERVER_URL") private readonly serverUrl: string,
        @Inject("CLIENT_URL") private readonly clientUrl: string,
    ) {

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

    submitOrder(customerData: CustomerData, productsSelected: Array<ProductSelection>): Observable<Array<FormElement>> {
        const orderProducts =
            productsSelected.map(x => new OrderProduct(x.quantity, x.product.id, x.product.variationId));

        return this.http.post<Array<FormElement>>(`${this.serverUrl}/api/v1/orders`,
            {
                callbackUrl: `${this.clientUrl}/order/{orderId}`,
                customerData: customerData,
                orderProducts: orderProducts
            });
    }
}