import { NgModule } from '@angular/core';
import { SharedModule } from '../shared.module';
import { TextInputComponent } from './shared/components/forms/text-input/text-input.component';
import { DateInputComponent } from './shared/components/forms/date-input/date-input.component';
import { ConfirmDialogComponent } from './shared/components/forms/confirm-dialog/confirm-dialog.component';
import { RolesModalComponent } from './shared/components/forms/roles-modal/roles-modal.component';
import { StepperComponent } from './shared/components/stepper/stepper.component';
import { NgxEditorModule } from 'ngx-editor';
import { NgxEditorComponent } from './shared/RichText/ngx-editor/ngx-editor.component';
import { AngularEditorComponent } from './shared/RichText/angular-editor/angular-editor.component';
import { AngularEditorModule } from '@kolkov/angular-editor';

import { CkeditorComponent } from './shared/RichText/ckeditor/ckeditor.component';
import { CKEditorModule } from '@ckeditor/ckeditor5-angular';

import { TinymceAngularComponent } from './shared/RichText/tinymce-angular/tinymce-angular.component';
import { EditorModule } from '@tinymce/tinymce-angular';
import { PipeModule } from './pipe/pipe.module';
import { HasRoleDirective } from './directives/has-role.directive';


@NgModule({
  declarations: [
    TextInputComponent,
    DateInputComponent,
    ConfirmDialogComponent,
    RolesModalComponent,
    HasRoleDirective,
    StepperComponent,



    NgxEditorComponent,
    AngularEditorComponent,
    CkeditorComponent,
    TinymceAngularComponent,

  ],
  imports: [
    SharedModule,
    PipeModule,


    NgxEditorModule.forRoot({
      locals: {
        // menu
        bold: 'Bold',
        italic: 'Italic',
        code: 'Code',
        blockquote: 'Blockquote',
        underline: 'Underline',
        strike: 'Strike',
        bullet_list: 'Bullet List',
        ordered_list: 'Ordered List',
        heading: 'Heading',
        h1: 'Header 1',
        h2: 'Header 2',
        h3: 'Header 3',
        h4: 'Header 4',
        h5: 'Header 5',
        h6: 'Header 6',
        align_left: 'Left Align',
        align_center: 'Center Align',
        align_right: 'Right Align',
        align_justify: 'Justify',
        text_color: 'Text Color',
        background_color: 'Background Color',

        // popups, forms, others...
        url: 'URL',
        text: 'Text',
        openInNewTab: 'Open in new tab',
        insert: 'Insert',
        altText: 'Alt Text',
        title: 'Title',
        remove: 'Remove',
      },
    }),

    AngularEditorModule,
    CKEditorModule,
    EditorModule
  ],
  exports: [
    PipeModule,

    TextInputComponent,
    DateInputComponent,

    NgxEditorComponent,
    NgxEditorModule,

    AngularEditorComponent,
    AngularEditorModule,

    CkeditorComponent,
    CKEditorModule,

    TinymceAngularComponent,
    EditorModule,

    StepperComponent,
  ]

})
export class GeneralModule { }
