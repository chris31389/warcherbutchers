import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StoreSnippetService } from './store-snippet/store-snippet.service';
import { StoreSnippetComponent } from './store-snippet/store-snippet.component';
import { HomeComponent } from './home/home.component';
import { HogComponent } from './hog/hog.component';
import { GangComponent } from './gang/gang.component';
import { ChristmasOrdersComponent } from './christmas-orders/christmas-orders.component';
import { SharedModule } from '../shared/shared.module';
import { RouterModule } from '@angular/router';
import { ScriptHackComponent } from './script-hack/script-hack.component';

@NgModule({
    imports: [
        CommonModule,
        SharedModule,
        RouterModule.forChild([{ path: "home", component: HomeComponent }])
    ],
    declarations: [StoreSnippetComponent, HomeComponent, HogComponent, GangComponent, ChristmasOrdersComponent, ScriptHackComponent],
    providers: [StoreSnippetService]
})
export class HomeModule { }
