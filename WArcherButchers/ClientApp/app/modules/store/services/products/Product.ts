import {Variation} from "./";

export class Product {
    name: string;
    categories: Array<string>;
    description: string;
    detailedDescription: string;
    variations: Array<Variation>;

    constructor(json?:any) {
        if (json) {
            this.name = json.name ? json.name : "";
            this.description = json.description ? json.description : "";
            this.detailedDescription = json.detailedDescription ? json.detailedDescription : "";
        }
    }
}