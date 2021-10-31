import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ViColorComponent } from './vi-color/vi-color.component';
import { RouterModule, Routes } from '@angular/router';
import { SettingHomeComponent } from './setting-home/setting-home.component';
import { OurcompanyComponent } from './ourcompany/ourcompany.component';
import { OurCompanyFormComponent } from './ourcompany/our-company-form/our-company-form.component';
import { DesignRecordCreateComponent } from './design-record/design-record-create/design-record-create.component';
import { DesignRecordEditComponent } from './design-record/design-record-edit/design-record-edit.component';


const routes: Routes = [
  { path: "vicolor", component: ViColorComponent },
  { path: "settinghome", component: SettingHomeComponent },
  { path: "webdesign", component: SettingHomeComponent },
  // // { path: "products/edit/:id", component: ProductEditComponent, canDeactivate: [PreventUnsavedChangesGuard] },
  { path: "ourcompany", component: OurcompanyComponent },
  { path: "settinghome/company/form", component: OurCompanyFormComponent },
  { path: "designrecord", component: DesignRecordCreateComponent },
  { path: "designrecord/:id", component: DesignRecordEditComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SettingRoutingModule { }
