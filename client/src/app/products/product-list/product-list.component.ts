import { HttpClient } from '@angular/common/http';
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, NgForm, Validators } from '@angular/forms';
import { Title } from '@angular/platform-browser';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { IProduct } from 'src/app/products/product';
import { IPagination } from 'src/app/_models/pagination';
import { ProductService } from '../product.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.scss']
})
export class ProductListComponent implements OnInit {
  products$: Observable<IProduct[]>;
  currentPage: any;
  pagination: IPagination;
  perPageItems = [12, 24, 36, 48];
  itemsPerPage: number = 12;  //Initial items perPage


  constructor(private productService: ProductService, private httpClient: HttpClient, private title: Title) { }

  ngOnInit(): void {
    this.title.setTitle("产品列表 - 科朗管理平台");
    this.loadProducts();
  }

  loadProducts() {
    this.products$ = this.productService.getProducts();
  }

  pageChanged(event) {
    this.currentPage = event;
  }

  onPageItemsChange(event): void {
    this.itemsPerPage = event.target.value;
    this.currentPage = 1;
    this.loadProducts();
  }

}
