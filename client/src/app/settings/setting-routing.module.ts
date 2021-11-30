import { NgModule } from '@angular/core';
import { ViColorComponent } from './vi-color/vi-color.component';
import { RouterModule, Routes } from '@angular/router';
import { SettingHomeComponent } from './setting-home/setting-home.component';
import { DesignRecordCreateComponent } from './design-record/design-record-create/design-record-create.component';
import { DesignRecordEditComponent } from './design-record/design-record-edit/design-record-edit.component';
import { OurcompanyListComponent } from './ourcompany/ourcompany-list/ourcompany-list.component';
import { CategpryHomeComponent } from '../products/category/categpry-home/categpry-home.component';


const routes: Routes = [
  { path: "vicolor", component: ViColorComponent },
  { path: "settinghome", component: CategpryHomeComponent },
  { path: "webdesign", component: SettingHomeComponent },
  // // { path: "products/edit/:id", component: ProductEditComponent, canDeactivate: [PreventUnsavedChangesGuard] },
  { path: "ourcompany", component: OurcompanyListComponent },
  // { path: "settinghome/company/form", component: OurCompanyFormComponent },
  { path: "designrecord", component: DesignRecordCreateComponent },
  { path: "designrecord/:id", component: DesignRecordEditComponent },
  { path: "product-category", component: CategpryHomeComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SettingRoutingModule { }
