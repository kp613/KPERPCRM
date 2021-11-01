import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { SharedModule } from '../shared.module';
import { TextInputComponent } from './components/forms/text-input/text-input.component';
import { FormControl } from '@angular/forms';
import { DateInputComponent } from './components/forms/date-input/date-input.component';
import { defineLocale } from 'ngx-bootstrap/chronos';
import { deLocale } from 'ngx-bootstrap/locale';
import { ConfirmDialogComponent } from './components/forms/confirm-dialog/confirm-dialog.component';
import { RolesModalComponent } from './components/forms/roles-modal/roles-modal.component';
import { HasRoleDirective } from '../_directives/has-role.directive';
import { StepperComponent } from './components/stepper/stepper.component';
import { AngularEditorComponent } from './RichText/angular-editor/angular-editor.component';

@NgModule({
  declarations: [
    TextInputComponent,
    DateInputComponent,
    ConfirmDialogComponent,
    RolesModalComponent,
    HasRoleDirective,
    StepperComponent,


    AngularEditorComponent,
  ],
  imports: [
    SharedModule,
  ],
  exports: [
    TextInputComponent,
    DateInputComponent,

    AngularEditorComponent,
  ]

})
export class GeneralModule { }
