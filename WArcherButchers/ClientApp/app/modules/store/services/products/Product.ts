import {Variation} from "./";
import { Price} from "../../../shared";

export class Product {
    id: string;
    name: string;
    categories = new Array<string>();
    description: string;
    detailedDescription: string;
    imageId: string;
    imageUrl: string;
    variationId: string;
    pricePerKilo: Price;
    price: Price;
    oldPrice: Price;
    isSpeciality: boolean;

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
            this.isSpeciality = json.isSpeciality || false;

            if (Array.isArray(json.categories)) {
                json.categories.forEach(category => this.categories.push(category));
            }
        }
    }

    containsCategory = (category: string) => this.categories.findIndex(x => x === category) >= 0;
}