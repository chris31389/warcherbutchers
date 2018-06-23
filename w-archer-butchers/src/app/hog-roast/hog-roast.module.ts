import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BossMessageComponent } from './boss-message/boss-message.component';
import { HogRoastComponent } from './hog-roast/hog-roast.component';
import { OurPatchComponent } from './our-patch/our-patch.component';
import { StoryComponent } from './story/story.component';
import { RouterModule } from '@angular/router';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  imports: [
    CommonModule,
    SharedModule,
    RouterModule.forChild([{ path: "hog-roast", component: HogRoastComponent }])
  ],
  declarations: [BossMessageComponent, HogRoastComponent, OurPatchComponent, StoryComponent]
})
export class HogRoastModule { }
