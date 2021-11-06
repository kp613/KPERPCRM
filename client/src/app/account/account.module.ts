import { NgModule } from '@angular/core';
import { SharedModule } from '../shared.module';
import { RoleListComponent } from './role/role-list/role-list.component';



@NgModule({
  declarations: [
    RoleListComponent
  ],
  imports: [
    SharedModule
  ]
})
export class AccountModule { }
