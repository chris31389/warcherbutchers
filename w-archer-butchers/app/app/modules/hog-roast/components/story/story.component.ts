import { Component } from "@angular/core";

@Component({
    selector: "story",
    templateUrl: "./story.component.html",
    styleUrls: ["./story.component.css"]
})
export class StoryComponent {
    stories = [
    {
        "caption": "Ever wondered what goes into making one of our mouth watering Hog Roasts?",
        "img": "Hog-Roast-Ready-To-Eat2.jpg",
        "alt": "Mouth Watering Hog Roast",
        "imgright": true,
        "order": 1
    }, {
        "caption": "The hog starts its journey locally in South Leicestershire.",
        "img": "Map-of-Leicestershire.jpg",
        "alt": "Sourced Locally in South Leicestershire",
        "imgright": false,
        "order": 2
    }, {
        "caption":
        "It gets marinated with cider and herbs before being slowly cooked and rotated. The slower the cooking, the more mouth watering!",
        "img": "SlowCooking.jpg",
        "alt": "Marinated with Cider and Herbs",
        "imgright": true,
        "order": 3
    }, {
        "caption": "We need to make sure that the meat is extra mouth-watering before preparing to serve it up.",
        "img": "CookingCut2.jpg",
        "alt": "Slow cooking for at least 10 hours",
        "imgright": false,
        "order": 4
    }, {
        "caption": "Our skilled butchers carve and serve your hog. Each hog serves between 100-120 servings.",
        "img": "CookingCut4.jpg",
        "alt": "Skilled butchers carve your hog",
        "imgright": true,
        "order": 5
    }, {
        "caption": "Finally you can enjoy.",
        "img": "ReadyToServe.jpg",
        "alt": "Tasty Hog Roast Serving",
        "imgright": false,
        "order": 6
    }];

    getStoriesOrdered = () => this.stories.sort((a,b) => a.order - b.order);
}