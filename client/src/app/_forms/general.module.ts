import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { SharedModule } from '../shared.module';
import { TextInputComponent } from './text-input/text-input.component';
import { FormControl } from '@angular/forms';
import { DateInputComponent } from './date-input/date-input.component';
import { defineLocale } from 'ngx-bootstrap/chronos';
import { deLocale } from 'ngx-bootstrap/locale';
import { ConfirmDialogComponent } from './confirm-dialog/confirm-dialog.component';
import { RolesModalComponent } from './roles-modal/roles-modal.component';
import { HasRoleDirective } from '../_directives/has-role.directive';

@NgModule({
  declarations: [
    TextInputComponent,
    DateInputComponent,
    ConfirmDialogComponent,
    RolesModalComponent,
    HasRoleDirective,
  ],
  imports: [
    CommonModule,
    SharedModule,


  ],
  exports: [
    TextInputComponent,
    DateInputComponent
  ]

})
export class GeneralModule { }
