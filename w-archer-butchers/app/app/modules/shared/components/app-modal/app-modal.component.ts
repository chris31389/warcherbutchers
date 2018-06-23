import { Component } from "@angular/core";

@Component({
    selector: "app-modal",
    templateUrl: "./app-modal.component.html",
    styleUrls: ["./app-modal.component.css"]
})

export class AppModalComponent {
    visible = false;
    private visibleAnimate = false;

    show(): void {
        this.visible = true;
        setTimeout(() => this.visibleAnimate = true, 100);
    }

    hide(): void {
        this.visibleAnimate = false;
        setTimeout(() => this.visible = false, 300);
    }

    onContainerClicked(event: MouseEvent): void {
        if ((<HTMLElement>event.target).classList.contains('modal')) {
            this.hide();
        }
    }
}