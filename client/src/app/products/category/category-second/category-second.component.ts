import { HttpClient } from '@angular/common/http';
import { Component, Input, OnChanges, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

import { ToastrService } from 'ngx-toastr';
import { ICategoryFirst } from '../category-first/categoryFirst';
import { CategoryService } from '../category.service';
import { ICategorySecond } from './categorySecond';

@Component({
  selector: 'app-category-second',
  templateUrl: './category-second.component.html',
  styleUrls: ['./category-second.component.scss']
})
export class CategorySecondComponent implements OnInit, OnChanges {
  @Input() getCategoryFirst: ICategoryFirst;
  isEdit: boolean = false;

  isAddSecond: boolean = false;

  categorySecond: ICategorySecond;
  categorySeconds: ICategorySecond[];

  constructor(
    private httpClient: HttpClient,
    private formBuilder: FormBuilder,
    private toastr: ToastrService,
    private router: Router,
    private route: ActivatedRoute,
    private categoryService: CategoryService
  ) {
    // this.getCategoryFirst;
  }

  ngOnInit(): void {
  }

  ngOnChanges(): void {
    this.loadCategorySecondList();
  }

  loadCategorySecondList() {
    if (this.getCategoryFirst) {
      this.categoryService.getSecondLists(this.getCategoryFirst.id).subscribe(res => {
        this.categorySeconds = res;
      }, error => {
        console.log(error);
      })
    }
    this.categorySeconds = null;  //当二级中没有list时为空，否则会停留在原先的list上
  }

  addSecond() {
    this.isAddSecond = !this.isAddSecond;
    this.isEdit = false;
  }

  onEdit(categorySecond: any) {
    this.isEdit = true;
    this.isAddSecond = true;
    this.categorySecond = categorySecond;
  }

}
