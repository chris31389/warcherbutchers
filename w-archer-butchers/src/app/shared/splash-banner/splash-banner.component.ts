import { Component, Input, Inject } from '@angular/core';
import { DOCUMENT, DomSanitizer } from '@angular/platform-browser';
import { PageScrollInstance, PageScrollService } from 'ngx-page-scroll';

@Component({
  selector: 'app-splash-banner',
  templateUrl: './splash-banner.component.html',
  styleUrls: ['./splash-banner.component.scss']
})
export class SplashBannerComponent {
  @Input() imgSrc: string;
  @Input() adjective: string;
  @Input() title: string;
  @Input() caption: string;
  @Input() subCaption: string;
  @Input() target: string;

  constructor(public sanitizer: DomSanitizer,
    private readonly pageScrollService: PageScrollService,
    @Inject(DOCUMENT) private document: any) {
  }

  public goToTarget = () => {
    let pageScrollInstance = PageScrollInstance.newInstance({
      document: this.document,
      scrollTarget: this.target,
      pageScrollDuration: 1000,
      pageScrollOffset: 50
    });
    this.pageScrollService.start(pageScrollInstance);
  };

  getImageStyle = () => this.sanitizer.bypassSecurityTrustStyle(
    `linear-gradient(rgba(0, 0, 0, 0.5),rgba(0, 0, 0, 0.5)), url(${this.imgSrc})`);
}
