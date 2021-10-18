import { HttpClient } from '@angular/common/http';
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { environment } from 'src/environments/environment';
import { Product } from '../product';
import { ProductService } from '../product.service';

@Component({
  selector: 'app-product-edit',
  templateUrl: './product-edit.component.html',
  styleUrls: ['./product-edit.component.scss']
})
export class ProductEditComponent implements OnInit {
  product: Product;
  id: number;
  casno: string;
  imageUrl = environment.url;
  productImg: string;
  editProductForm: FormGroup;

  constructor(
    private productService: ProductService,
    private httpClient: HttpClient,
    private fb: FormBuilder,
    private toastr: ToastrService,
    private router: Router,
    private route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    // this.loadProduct();
    this.editForm();
  }

  editForm() {
    this.editProductForm = this.fb.group({
      id: [''],
      casNo: ['', [Validators.required, Validators.pattern('[1-9][0-9]{1,10}-[0-9]{2}-[0-9]{1}')]],
      productCode: [''],
      productName: [''],
      productNameCN: ['']
    });

    this.id = this.route.snapshot.params['id'];
    this.productService.getProductById(this.id).subscribe(response => {
      this.casno = response.casNo;
      this.productImg = this.imageUrl + '/content/cas/' + this.casno + '.png';
      this.editProductForm.patchValue(response);
    })
  }



  onUpdateProduct() {
    this.productService.update(this.id, this.editProductForm.value).subscribe((res) => {
      this.toastr.success('修改产品成功');
    }, (error) => {
      this.toastr.error(error.error);
    })
  }

}
