import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Product } from 'src/app/shared/product/product';

@Injectable()
export class StoreSnippetService {
    private readonly path = "/api/v1/products";

    constructor(private readonly http: HttpClient) { }

    get randomProduct(): Observable<Product> {
        return this.http
            .get(this.path + "/random")
            .pipe(map(response => new Product(response)));
    }
}
