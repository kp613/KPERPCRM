import { HttpClient } from '@angular/common/http';
import { Component, Input, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { ActivatedRoute, NavigationEnd, Router } from '@angular/router';
import { Validators } from 'ngx-editor';
import { ToastrService } from 'ngx-toastr';
import { ICategoryFirst } from '../category-first/categoryFirst';
import { CategoryService } from '../category.service';
import { ICategorySecond } from './categorySecond';

@Component({
  selector: 'app-category-second',
  templateUrl: './category-second.component.html',
  styleUrls: ['./category-second.component.scss']
})
export class CategorySecondComponent implements OnInit {
  @Input() getCategoryFirst: ICategoryFirst;

  firstId: number;

  isAddSecond: boolean = false;

  categorySeconds: ICategorySecond[];
  categorySecond: ICategorySecond;

  addGroupForm: FormGroup;

  constructor(
    private httpClient: HttpClient,
    private formBuilder: FormBuilder,
    private toastr: ToastrService,
    private router: Router,
    private route: ActivatedRoute,
    private categoryService: CategoryService
  ) {
    this.getCategoryFirst;
  }

  ngOnInit(): void {
    this.createForm();
    this.loadCategorySecondList();
  }

  createForm() {
    this.addGroupForm = this.formBuilder.group({
      productCategoryFirstId: ['', [Validators.required]],
      nameCh: ['', [Validators.required]],
      nameEn: ['', [Validators.required]],
    });
    this.firstId = this.route.snapshot.params['firstId'];
  }

  onSubmit() {
    this.categoryService.firstCreate(this.addGroupForm.value).subscribe((res: any) => {
      this.toastr.success('增加产品次类别成功');
      this.addGroupForm.reset();
    }, (error) => {
      this.toastr.error(error.error);
    })
  }

  loadCategorySecondList() {
    this.categoryService.getSecondLists(this.firstId).subscribe(res => {
      this.categorySeconds = res;

      //firstId改变后只刷新这个模块
      this.router.routeReuseStrategy.shouldReuseRoute = function () {
        return false;
      };
      this.router.events.subscribe((event) => {
        if (event instanceof NavigationEnd) {
          // Trick the Router into believing it's last link wasn't previously loaded
          this.router.navigated = true;
        }
      });

    }, error => {
      console.log(error);
    })
  }

  resetSecond() {
    this.addGroupForm.reset();
  }

  addSecond() {
    this.isAddSecond = true;
  }


}
