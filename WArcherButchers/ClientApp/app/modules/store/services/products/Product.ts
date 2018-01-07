import {Variation} from "./";
import { Price} from "../../../shared";

export class Product {
    id: string;
    name: string;
    categories: Array<string>;
    description: string;
    detailedDescription: string;
    imageId: string;
    imageUrl: string;
    variationId: string;
    pricePerKilo: Price;
    price: Price;
    oldPrice: Price;

    constructor(json?:any) {
        if (json) {
            this.id = json.id;
            this.name = json.name;
            this.description = json.description;
            this.detailedDescription = json.detailedDescription;
            this.imageId = json.imageId;
            this.variationId = json.variationId;
            this.pricePerKilo = json.pricePerKilo ? new Price(json.pricePerKilo) : null;
            this.price = json.price ? new Price(json.price) : null;
            this.oldPrice = json.oldPrice ? new Price(json.oldPrice) : null;
            this.imageUrl = json.imageUrl;
        }
    }
}