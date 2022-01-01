import { HttpClient } from '@angular/common/http';
import { Component, Input, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { Validators } from 'ngx-editor';
import { ToastrService } from 'ngx-toastr';
import { ICategoryFirst } from '../../category-first/categoryFirst';
import { CategoryService } from '../../category.service';
import { ICategorySecond } from '../categorySecond';

@Component({
  selector: 'app-category-second-add',
  templateUrl: './category-second-add.component.html',
  styleUrls: ['./category-second-add.component.scss']
})
export class CategorySecondAddComponent implements OnInit {
  @Input() getCategoryFirst: ICategoryFirst;
  @Input() isAddSecond: any;

  categorySecond: ICategorySecond;
  categorySeconds: ICategorySecond[];

  addGroupSecondForm: FormGroup;

  constructor(
    private httpClient: HttpClient,
    private formBuilder: FormBuilder,
    private router: Router,
    private toastr: ToastrService,
    private categoryService: CategoryService
  ) { }

  ngOnInit(): void {
    this.createForm();
  }

  createForm() {
    this.addGroupSecondForm = this.formBuilder.group({
      productCategoryFirstId: [this.getCategoryFirst.id, [Validators.required]],
      nameCh: ['', [Validators.required]],
      nameEn: ['', [Validators.required]],
    });

  }

  onSubmit() {
    this.categoryService.secondCreate(this.addGroupSecondForm.value).subscribe((res: any) => {
      this.toastr.success('增加产品次类别成功');
    }, (error) => {
      this.toastr.error(error.error);
    })
    this.categorySecond = this.addGroupSecondForm.value;
    this.addGroupSecondForm.reset();
  }

  resetSecond() {
    this.addGroupSecondForm.reset();
  }
}
