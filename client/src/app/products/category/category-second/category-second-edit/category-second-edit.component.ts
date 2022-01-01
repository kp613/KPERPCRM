import { Component, Input, OnInit, Output } from '@angular/core';
import { Location } from '@angular/common';
import { Validators } from 'ngx-editor';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { CategoryService } from '../../category.service';
import { ICategorySecond } from '../categorySecond';
import { EventEmitter } from 'stream';

@Component({
  selector: 'app-category-second-edit',
  templateUrl: './category-second-edit.component.html',
  styleUrls: ['./category-second-edit.component.scss']
})
export class CategorySecondEditComponent implements OnInit {
  @Input() isEdit: any;
  @Input() categorySecondForEdit: ICategorySecond;

  editGroupSecondForm: FormGroup;

  constructor(
    private categoryService: CategoryService,
    private fb: FormBuilder,
    private toastr: ToastrService,
    private location: Location,
  ) { }

  ngOnInit(): void {
    this.editForm();
  }

  editForm() {
    this.editGroupSecondForm = this.fb.group({
      id: [''],
      productCategoryFirstId: [''],
      nameCh: ['', [Validators.required]],
      nameEn: ['', [Validators.required]],
    });

    this.editGroupSecondForm.patchValue(this.categorySecondForEdit);
  }

  onSubmit() {
    this.categoryService.secondUpdate(this.categorySecondForEdit.id, this.editGroupSecondForm.value).subscribe((res: any) => {
      this.toastr.success('修改产品次类别成功');
    }, (error) => {
      this.toastr.error(error.error);
    })
    // this.categorySecondForEdit = this.editGroupSecondForm.value;

    this.editGroupSecondForm.reset();
  }

  cancel(): void {
    this.isEdit = false;
  }

}
