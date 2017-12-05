import { Injectable } from "@angular/core";

@Injectable()
export class CategoryService {
    getOptions = ():Array<string> => ["Beef", "Lamb", "Pork", "Chicken", "Game", "Christmas", "South African", "Bulk"];
    getSpecialityOptions = (): Array<string> => ["South African"];
}