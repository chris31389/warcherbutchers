import { Component, OnInit, Output, Input, EventEmitter } from '@angular/core';
import { Product } from './product';

@Component({
    selector: 'app-product',
    templateUrl: './product.component.html',
    styleUrls: ['./product.component.scss']
})
export class ProductComponent implements OnInit {
    @Input() product: Product;
    @Output() addToBasket = new EventEmitter<Product>();
    isAddToBasketUsed = false;

    ngOnInit() {
        this.isAddToBasketUsed = this.addToBasket.observers.length > 0;
    }

    addItem = () => this.addToBasket.emit(this.product);
}
