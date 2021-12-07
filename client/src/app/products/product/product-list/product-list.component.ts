import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { IPagination } from '../../../_core/pagination/pagination';
import { IProduct } from '../../../products/product';
import { ProductService } from '../../product.service';
import { ProductParams } from '../../productParams';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.scss']
})
export class ProductListComponent implements OnInit {
  // products$: Observable<IProduct[]>;
  products: IProduct[] = [];
  product: IProduct;
  pagination: IPagination;
  productParams: ProductParams;
  // pageSize = 60;
  // pageNumber = 1;


  // currentPage: 1;
  // count = 0;
  perPageItems = [12, 24, 36, 48];
  // itemsPerPage: number = 12;  //Initial items perPage

  searchItem = '';


  constructor(
    private productService: ProductService,
    private httpClient: HttpClient,
    private title: Title) {
    this.productParams = this.productService.getProductParams();
  }

  ngOnInit(): void {
    this.title.setTitle("产品列表 - 科朗管理平台");
    this.loadProducts();
  }

  // getRequestParams(searchItem: string, currentPage: number, itemsPerPage: number): any {
  //   let params: any = {};

  //   if (searchItem) {
  //     params[`searchItem`] = searchItem;
  //   }

  //   if (currentPage) {
  //     params[`currentPage`] = currentPage - 1;
  //     params[`itemsPerPage`] = itemsPerPage;
  //     params[`searchItem`] = searchItem;
  //   }

  //   if (itemsPerPage) {
  //     params[`itemsPerPage`] = itemsPerPage;
  //   }

  //   return params;
  // }

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
    this.productService.setProductParams(this.productParams);
    this.productService.getProducts(this.productParams).subscribe(response => {
      this.products = response.result;
      this.pagination = response.pagination;
    })
    // this.products$ = this.productService.getProducts();
  }

  pageChanged(event) {
    this.productParams.pageNumber = event;
    this.loadProducts();
  }

  onPageItemsChange(event): void {
    this.productParams.pageSize = event.target.value;
    this.productParams.pageNumber = 1;
    this.loadProducts();
  }

  // pageChanged(event: any) {
  //   this.productParams.pageNumber = event.page;
  //   this.productService.setProductParams(this.productParams);
  //   this.loadProducts();
  // }

}
