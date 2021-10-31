import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../shared.module';
import { ViColorComponent } from './vi-color/vi-color.component';
import { SettingHomeComponent } from './setting-home/setting-home.component';
import { SettingSidebarComponent } from './setting-sidebar/setting-sidebar.component';
import { OurcompanyComponent } from './ourcompany/ourcompany.component';
import { GeneralModule } from '../_shared/general.module';
import { OurCompanyFormComponent } from './ourcompany/our-company-form/our-company-form.component';
import { DesignRecordCreateComponent } from './design-record/design-record-create/design-record-create.component';
import { DesignRecordListComponent } from './design-record/design-record-list/design-record-list.component';
import { DesignRecordEditComponent } from './design-record/design-record-edit/design-record-edit.component';



@NgModule({
  declarations: [
    ViColorComponent,
    SettingHomeComponent,
    SettingSidebarComponent,
    OurcompanyComponent,
    OurCompanyFormComponent,
    DesignRecordCreateComponent,
    DesignRecordListComponent,
    DesignRecordEditComponent
  ],
  imports: [
    SharedModule,
    GeneralModule
  ]
})
export class SettingModule { }
