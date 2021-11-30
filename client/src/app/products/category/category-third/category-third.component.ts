import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { Validators } from 'ngx-editor';
import { ToastrService } from 'ngx-toastr';
import { CategoryService } from '../category.service';
import { ICategoryThird } from './categoryThird';

@Component({
  selector: 'app-category-third',
  templateUrl: './category-third.component.html',
  styleUrls: ['./category-third.component.scss']
})
export class CategoryThirdComponent implements OnInit {

  categoryThirds: ICategoryThird[];
  categoryThird: ICategoryThird;

  addGroupForm: FormGroup;

  constructor(
    private httpClient: HttpClient,
    private formBuilder: FormBuilder,
    private toastr: ToastrService,
    private router: Router,
    private categoryService: CategoryService
  ) { }

  createForm() {
    this.addGroupForm = this.formBuilder.group({
      productCategorySecondId: ['', [Validators.required]],
      nameCh: ['', [Validators.required]],
      nameEn: [''],
    });
  }

  ngOnInit(): void {
  }

  reset() {
    this.addGroupForm.reset();
  }

}
