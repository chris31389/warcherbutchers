import { Observable } from "rxjs/Rx";
import { Product } from "./";
import { Injectable, Inject } from "@angular/core";
import { HttpClient, HttpErrorResponse } from "@angular/common/http";

@Injectable()
export class ProductService {
    private readonly path = "/api/v1/products";

    constructor(
        private readonly http: HttpClient,
    ) {
    }

    getProducts = (): Observable<Array<Product>> => this.http
        .get(this.path)
        .map(response => {
            const products = new Array<Product>();

            if (response && Array.isArray(response)) {
                response.forEach(json => products.push(new Product(json)));
            }

            return products;
        });

    getRandomProduct = (): Observable<Product> => this.http
        .get(this.path + "/random")
        .map(response => new Product(response));

    getSpecialityProducts = (): Observable<Array<Product>> => this.http
        .get(this.path)
        .map(response => {
            const products = new Array<Product>();

            if (response && Array.isArray(response)) {
                response.forEach(json => {
                    const product = new Product(json);
                    if (product.isSpeciality) {
                        products.push(product);
                    }
                });
            }

            return products;
        });
}