import { HttpClient } from '@angular/common/http';
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, NgForm, Validators } from '@angular/forms';
import { Title } from '@angular/platform-browser';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { Product } from 'src/app/products/product';
import { ProductService } from '../product.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.scss']
})
export class ProductListComponent implements OnInit {
  products$: Observable<Product[]>;
  newProduct: Product[];
  addProductForm: FormGroup;
  model: any = {};
  @ViewChild('addProduct') addProduct: NgForm;

  constructor(private productService: ProductService, private httpClient: HttpClient, private title: Title, private fb: FormBuilder, private toastr: ToastrService) { }

  ngOnInit(): void {
    this.title.setTitle("产品列表 - 科朗管理平台");
    this.initializeForm();

    this.products$ = this.productService.readAll();
  }

  initializeForm() {
    this.addProductForm = this.fb.group({
      casno: ['', [Validators.required, Validators.pattern('[1-9][0-9]{1,10}-[0-9]{2}-[0-9]{1}')]]
    })
  }

  onSaveForm() {
    this.productService.create(this.addProduct.value).subscribe((res) => {
      this.toastr.success('增加产品成功');
      this.cancel();
    }, (error) => {
      this.toastr.error(error.error);
      this.productService.readAll();
    })
  }

  cancel() {
    this.addProduct.reset();
  }
}
