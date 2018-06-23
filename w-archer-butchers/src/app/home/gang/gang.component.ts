import { Component } from "@angular/core";

@Component({
    selector: "app-gang",
    templateUrl: "./gang.component.html",
    styleUrls: [ "./gang.component.scss" ]
})
export class GangComponent {
    employeeMessageIntro = "Sean (middle) leads Morgan (left) and Ash (right) in their daily Butchery duties.";
    employeeMessages = [
        "Sean, as the business owner, hardly gets time to himself.  When he does he enjoys playing football and spending time with the family.",
        "Morgan fills his spare time with mixed martial arts and all things gym related. He is keen on fine art and boasts a degree to his name.",
        "Ash in spare time likes to follow Leicester City, sampling the local night life and listening to kasabian."
        ];
}
