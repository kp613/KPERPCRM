import { HttpClient } from '@angular/common/http';
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormGroup, NgForm, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { environment } from 'src/environments/environment';
import { Product } from '../product';
import { ProductService } from '../product.service';

@Component({
  selector: 'app-product-add',
  templateUrl: './product-add.component.html',
  styleUrls: ['./product-add.component.scss']
})
export class ProductAddComponent implements OnInit {
  casno: string;
  product: Product;
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
