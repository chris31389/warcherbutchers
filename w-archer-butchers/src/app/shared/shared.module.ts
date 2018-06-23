import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ContactUsComponent } from './contact-us/contact-us.component';
import { SplashBannerComponent } from './splash-banner/splash-banner.component';
import { RouterModule } from '@angular/router';
import { ProductComponent } from './product/product.component';
import { PriceComponent } from './price/price.component';

@NgModule({
    imports: [
        CommonModule,
        RouterModule.forChild([{ path: "contact-us", component: ContactUsComponent }])
    ],
    declarations: [ContactUsComponent, SplashBannerComponent, ProductComponent, PriceComponent],
    exports: [ContactUsComponent, SplashBannerComponent, ProductComponent, PriceComponent]
})
export class SharedModule { }
