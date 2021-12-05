import { NgModule } from '@angular/core';
import { SharedModule } from '../shared.module';
import { RoleListComponent } from './role/role-list/role-list.component';
import { RegisterEditComponent } from './register/register-edit/register-edit.component';
import { RegisterComponent } from './register/register/register.component';
import { GeneralModule } from '../_core/general.module';
import { MemberMessagesComponent } from '../admin/message/member-messages/member-messages.component';
import { LoginComponent } from './login/login.component';
import { MemberCardComponent } from './members/member-card/member-card.component';
import { MemberDetailComponent } from './members/member-detail/member-detail.component';
import { MemberListComponent } from './members/member-list/member-list.component';



@NgModule({
  declarations: [
    RoleListComponent,
    RegisterEditComponent,
    RegisterComponent,
    LoginComponent,
    MemberListComponent,
    MemberCardComponent,
    MemberDetailComponent,
    MemberMessagesComponent
  ],
  imports: [
    SharedModule,
    GeneralModule,
  ],
  exports: [
    RegisterComponent,
    LoginComponent,
  ]
})
export class AccountModule { }
