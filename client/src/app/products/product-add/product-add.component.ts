import { HttpClient } from '@angular/common/http';
import { Component, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { FormGroup, NgForm, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { IProduct } from '../product';
import { ProductListComponent } from '../product-list/product-list.component';
import { ProductService } from '../product.service';
import { ProductParams } from '../productParams';

@Component({
  selector: 'app-product-add',
  templateUrl: './product-add.component.html',
  styleUrls: ['./product-add.component.scss']
})
export class ProductAddComponent implements OnInit {
  casno: string;
  // product: IProduct;
  addProductForm: FormGroup;

  constructor(
    private productService: ProductService,
    private httpClient: HttpClient,
    private fb: FormBuilder,
    private toastr: ToastrService,
    private router: Router) { }

  ngOnInit(): void {
    this.createForm();
  }


  createForm() {
    this.addProductForm = this.fb.group({
      casno: ['', [Validators.required, Validators.pattern('[1-9][0-9]{1,10}-[0-9]{2}-[0-9]{1}')]],
      productCode: [''],
      productname: [''],
      productnamecn: ['']
    })
  }

  onSaveForm() {
    this.productService.create(this.addProductForm.value).subscribe((res) => {
      this.toastr.success('增加产品成功');
    }, (error) => {
      this.toastr.error(error.error);
    })
  }


  cancel() {
    this.addProductForm.reset();
  }


}
