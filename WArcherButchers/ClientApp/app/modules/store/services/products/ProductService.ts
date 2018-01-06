import { Observable } from "rxjs/Rx";
import { Product } from "./";
import { Injectable } from "@angular/core";

@Injectable()
export class ProductService {
    private product = new Product({
        name: "Biltong",
        description: "Description",
        detailedDescription: "Detailed Description"
    });

    getProducts = (): Observable<Array<Product>> =>
        new Observable(observer => {
            const products = new Array<Product>();
            products.push(this.product);
            setTimeout(() => observer.next(products), 200);
            setTimeout(() => observer.complete(), 100);
        });

    getRandomProduct = (): Observable<Product> => 
        new Observable(observer => {
            setTimeout(() => observer.next(this.product), 200);
            setTimeout(() => observer.complete(), 100);
        });
}