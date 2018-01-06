import { Component /*, AfterViewInit*/
    } from "@angular/core";
import { Product, ProductService } from "../../../";

@Component({
    selector: "store-snippet",
    templateUrl: "./store-snippet.component.html",
    styleUrls: ["./store-snippet.component.css"]
})
export class StoreSnippetComponent /*implements AfterViewInit*/ {
    product: Product;
    storeInfo = {
        message: "There are many more products available for purchase.  Find out more by visiting our store.",
        linkMessage: "The Store"
    }

    constructor(private readonly productService: ProductService) {
        this.productService.getRandomProduct()
            .subscribe(x => this.product = x);
    }

/*

    ngAfterViewInit() {
        !function (d, s, id) {
            var js: any;
            const fjs = d.getElementsByTagName(s)[0];
            const p = 'https';
            if (!d.getElementById(id)) {
                js = d.createElement(s);
                js.id = id;
                js.src = p + "://platform.twitter.com/widgets.js";
                fjs.parentNode.insertBefore(js, fjs);
            }
        }(document, "script", "twitter-wjs");
    }*/
}