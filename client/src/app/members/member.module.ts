import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { SharedModule } from '../shared.module';
import { MemberListComponent } from './member-list/member-list.component';
import { MemberCardComponent } from './member-card/member-card.component';
import { MemberDetailComponent } from './member-detail/member-detail.component';
import { MemberEditComponent } from './member-edit/member-edit.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { UserComponent } from './user/user.component';
import { GeneralModule } from '../_forms/general.module';
import { MemberMessagesComponent } from './member-messages/member-messages.component';

@NgModule({
  declarations: [
    LoginComponent,
    RegisterComponent,
    UserComponent,
    MemberListComponent,
    MemberCardComponent,
    MemberDetailComponent,
    MemberEditComponent,
    MemberMessagesComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    SharedModule,

    GeneralModule
  ],
  exports: [
    LoginComponent,
    RegisterComponent,
    UserComponent,



  ]
})
export class MemberModule { }
