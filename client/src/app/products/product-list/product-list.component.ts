import { HttpClient } from '@angular/common/http';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { Subject } from 'rxjs';
import { Product } from 'src/app/_models/product';
import { ProductsService } from 'src/app/_services/product.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.scss']
})
export class ProductListComponent implements OnInit {
  products: Product[];
  newProduct: Product = new Product();



  constructor(private productsService: ProductsService, private httpClient: HttpClient, private title: Title) { }

  ngOnInit(): void {
    this.title.setTitle("产品列表 - 科朗管理平台");


    this.productsService.getProductsList().subscribe(
      (res: Product[] = []) => {
        // this.products = (res as any).data;

        this.products = res;
        // initiate our data table
        // this.dtTrigger.next();

      });
  }



  onSaveForm() {
    this.productsService.insertProduct(this.newProduct).subscribe((res) => {
      this.products.push(this.newProduct);
    }, (error) => {
      console.log(error);
    })
  }
}
