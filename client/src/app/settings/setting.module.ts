import { NgModule } from '@angular/core';
import { SharedModule } from '../shared.module';
import { ViColorComponent } from './vi-color/vi-color.component';
import { SettingHomeComponent } from './setting-home/setting-home.component';
import { SettingSidebarComponent } from './setting-sidebar/setting-sidebar.component';
import { DesignRecordCreateComponent } from './design-record/design-record-create/design-record-create.component';
import { DesignRecordListComponent } from './design-record/design-record-list/design-record-list.component';
import { DesignRecordEditComponent } from './design-record/design-record-edit/design-record-edit.component';
import { OurcompanyListComponent } from './ourcompany/ourcompany-list/ourcompany-list.component';
import { GeneralModule } from '../_shared/general.module';

@NgModule({
  declarations: [
    ViColorComponent,
    SettingHomeComponent,
    SettingSidebarComponent,
    DesignRecordCreateComponent,
    DesignRecordListComponent,
    DesignRecordEditComponent,
    OurcompanyListComponent
  ],
  imports: [
    SharedModule,
    GeneralModule,
  ],
  exports: [
    SettingSidebarComponent,   //Used in ProductModule for CategpryHomeComponent
  ]
})
export class SettingModule { }
