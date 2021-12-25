import { HttpClient } from '@angular/common/http';
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Validators } from 'ngx-editor';
import { ToastrService } from 'ngx-toastr';
import { CategorySecondComponent } from '../category-second/category-second.component';
import { CategoryService } from '../category.service';
import { ICategoryThird } from './categoryThird';

@Component({
  selector: 'app-category-third',
  templateUrl: './category-third.component.html',
  styleUrls: ['./category-third.component.scss']
})
export class CategoryThirdComponent implements OnInit {
  @ViewChild(CategorySecondComponent) getCategorySecond;

  secondId: number;

  isAddCategory = false;

  categoryThirds: ICategoryThird[];
  categoryThird: ICategoryThird;

  addGroupThirdForm: FormGroup;

  constructor(
    private httpClient: HttpClient,
    private fb: FormBuilder,
    private toastr: ToastrService,
    private router: Router,
    private route: ActivatedRoute,
    private categoryService: CategoryService
  ) { }

  createForm() {
    this.addGroupThirdForm = this.fb.group({
      productCategorySecondId: ['', [Validators.required]],
      nameCh: ['', [Validators.required]],
      nameEn: [''],
    });
    this.secondId = this.route.snapshot.params['firstId'];
  }

  ngOnInit(): void {
    this.createForm();
  }

  onSubmit() {
    // this.categoryService.firstCreate(this.addGroupSecondForm.value).subscribe((res: any) => {
    //   this.toastr.success('增加产品次类别成功');
    //   this.addGroupSecondForm.reset();
    // }, (error) => {
    //   this.toastr.error(error.error);
    // })
  }

  addCategory() {
    this.isAddCategory = !this.isAddCategory;
  }

  reset() {
    this.addGroupThirdForm.reset();
  }

}
