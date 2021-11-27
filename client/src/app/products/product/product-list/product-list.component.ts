import { HttpClient } from '@angular/common/http';
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, NgForm, Validators } from '@angular/forms';
import { Title } from '@angular/platform-browser';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { IProduct } from 'src/app/products/product';
import { IPagination } from 'src/app/_models/pagination';
import { ProductService } from '../../product.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.scss']
})
export class ProductListComponent implements OnInit {
  products$: Observable<IProduct[]>;
  products: IProduct[] = [];
  product: IProduct;

  currentPage: 1;
  count = 0;
  perPageItems = [12, 24, 36, 48];
  itemsPerPage: number = 12;  //Initial items perPage

  searchItem = '';


  constructor(private productService: ProductService, private httpClient: HttpClient, private title: Title) { }

  ngOnInit(): void {
    this.title.setTitle("产品列表 - 科朗管理平台");
    this.loadProducts();
  }

  getRequestParams(searchItem: string, currentPage: number, itemsPerPage: number): any {
    let params: any = {};

    if (searchItem) {
      params[`searchItem`] = searchItem;
    }

    if (currentPage) {
      params[`currentPage`] = currentPage - 1;
      params[`itemsPerPage`] = itemsPerPage;
      params[`searchItem`] = searchItem;
    }

    if (itemsPerPage) {
      params[`itemsPerPage`] = itemsPerPage;
    }

    return params;
  }

  // loadProducts(): void {
  //   const params = this.getRequestParams(this.searchItem, this.itemsPerPage, this.currentPage);

  //   this.productService.getProducts(params).subscribe(response => {
  //     const { products, totalItems } = response;
  //     this.products = products;
  //     this.count = totalItems;
  //     // console.log(response);
  //   }, error => {
  //     console.log(error);
  //   })
  // }

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
