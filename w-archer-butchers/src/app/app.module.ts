import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NgxPageScrollModule } from "ngx-page-scroll";

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { FooterComponent } from './footer/app-footer.component';
import { ButcheryClassesModule } from './butchery-classes/butchery-classes.module';
import { SharedModule } from './shared/shared.module';
import { HogRoastModule } from './hog-roast/hog-roast.module';
import { HomeModule } from './home/home.module';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    FooterComponent
  ],
  imports: [
    BrowserModule,
    SharedModule,
    RouterModule.forRoot([
      { path: "*", redirectTo: "" }
    ]),
    HttpClientModule,
    NgbModule.forRoot(),
    NgxPageScrollModule,
    ButcheryClassesModule,
    HogRoastModule,
    HomeModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
