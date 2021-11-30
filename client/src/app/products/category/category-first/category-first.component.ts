import { HttpClient } from '@angular/common/http';
import { AfterViewInit, Component, EventEmitter, OnInit, Output, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { error } from 'console';
import { ToastrService } from 'ngx-toastr';
import { CategorySecondComponent } from '../category-second/category-second.component';
import { CategoryService } from '../category.service';
import { ICategoryFirst } from './categoryFirst';

@Component({
  selector: 'app-category-first',
  templateUrl: './category-first.component.html',
  styleUrls: ['./category-first.component.scss']
})
export class CategoryFirstComponent implements OnInit {
  // @Output() getCategoryFirstEvent = new EventEmitter<string>();

  isAddFirst: boolean = false;

  categoryFirsts: ICategoryFirst[];

  categoryFirst: ICategoryFirst;

  addGroupForm: FormGroup;

  constructor(
    private httpClient: HttpClient,
    private formBuilder: FormBuilder,
    private toastr: ToastrService,
    private router: Router,
    private categoryService: CategoryService
  ) { }

  ngOnInit(): void {
    this.createForm();
    this.loadCategoryFirstList();
  }

  createForm() {
    this.addGroupForm = this.formBuilder.group({
      nameCh: ['', [Validators.required]],
      nameEn: ['', [Validators.required]],
    });
  }

  onSubmit() {
    this.categoryService.firstCreate(this.addGroupForm.value).subscribe((res: any) => {
      this.categoryFirsts.push(this.addGroupForm.value);
      this.toastr.success('增加产品主类别成功');
      this.addGroupForm.reset();
    }, (error) => {
      this.toastr.error(error.error);
    })
  }

  loadCategoryFirstList() {
    this.categoryService.getFirstLists().subscribe(res => {
      this.categoryFirsts = res;
    }, error => {
      console.log(error);
    })
  }

  resetFirst() {
    this.addGroupForm.reset();
  }

  addFirst() {
    this.isAddFirst = true;
  }

  setFirstValue(value: any) {
    this.categoryService.setCategoryFirst(value);
  }
}
