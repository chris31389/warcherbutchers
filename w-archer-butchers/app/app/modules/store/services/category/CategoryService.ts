import { Injectable } from "@angular/core";

@Injectable()
export class CategoryService {
    get categories(): Array<string> {
        return ["Beef", "Lamb", "Pork", "Chicken", "Game", "Christmas", "South African", "Bulk"];
    }

    get specialityCategories(): Array<string> { return ["South African"]; }
}