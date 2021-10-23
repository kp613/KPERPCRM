import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../shared.module';
import { ViColorComponent } from './vi-color/vi-color.component';
import { SettingHomeComponent } from './setting-home/setting-home.component';
import { SettingSidebarComponent } from './setting-sidebar/setting-sidebar.component';
import { OurcompanyComponent } from './ourcompany/ourcompany.component';



@NgModule({
  declarations: [
    ViColorComponent,
    SettingHomeComponent,
    SettingSidebarComponent,
    OurcompanyComponent
  ],
  imports: [
    SharedModule,
  ]
})
export class SettingModule { }
