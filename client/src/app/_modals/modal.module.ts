import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { MemberModule } from 'src/app/account/members/member.module';
import { SharedModule } from 'src/app/shared.module';
import { RolesModalComponent } from './roles-modal/roles-modal.component';
import { ConfirmDialogComponent } from './confirm-dialog/confirm-dialog.component';



@NgModule({
  declarations: [
    RolesModalComponent,
    ConfirmDialogComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    MemberModule,
    SharedModule,
  ]
})
export class ModalModule { }
