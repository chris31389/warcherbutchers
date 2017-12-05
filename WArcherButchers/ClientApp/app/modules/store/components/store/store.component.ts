import { Component } from "@angular/core";
import { CategoryService } from "../../";

@Component({
    selector: "store",
    templateUrl: "./store.component.html",
    styleUrls:["./store.component.css"] 
})
export class StoreComponent {
    searchTerm: string = "";
    categories: Array<string> = [];

    constructor(private categoryService: CategoryService) {
        this.categories = categoryService.getOptions();
    }

    updateFilterItems = () => { }
    includeCategory = (category: any) => {}
}
