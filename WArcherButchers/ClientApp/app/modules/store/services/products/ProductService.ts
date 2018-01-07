import { Observable } from "rxjs/Rx";
import { Product } from "./";
import { Injectable } from "@angular/core";

@Injectable()
export class ProductService {
    private product = new Product({
        "productId": "55fd2d300a85b0ff7af2d152",
        "name": "Leicestershire long horn Minced Beef (5kg)",
        "description": "Makes a tasty chilli!",
        "imageId": "55eed9cf672ed712a1b55048",
        "price": { "major": 29, "minor": 0 },
        "variationId": "55fd309b0a85b0ff7af2d199",
        "weight": { "unit": "kg", "value": 5 },
        "categories": ["Beef", "Bulk"],
        "pricePerKilo": { "major": 5, "minor": 80 }
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
            observer.next(this.product);
            observer.complete();
        });
}