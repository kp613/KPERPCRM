import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ViColorComponent } from './vi-color/vi-color.component';
import { RouterModule, Routes } from '@angular/router';
import { SettingHomeComponent } from './setting-home/setting-home.component';
import { OurcompanyComponent } from './ourcompany/ourcompany.component';


const routes: Routes = [
  { path: "settinghome/vicolor", component: ViColorComponent },
  { path: "settinghome", component: SettingHomeComponent },
  // // { path: "products/edit/:id", component: ProductEditComponent, canDeactivate: [PreventUnsavedChangesGuard] },
  { path: "settinghome/company", component: OurcompanyComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SettingRoutingModule { }
