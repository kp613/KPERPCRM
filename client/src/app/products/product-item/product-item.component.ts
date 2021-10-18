import { HttpClient } from '@angular/common/http';
import { Component, Input, OnInit, Output } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { environment } from 'src/environments/environment';
import * as internal from 'stream';
import { Product } from '../product';
import { ProductService } from '../product.service';

@Component({
  selector: 'app-product-item',
  templateUrl: './product-item.component.html',
  styleUrls: ['./product-item.component.scss']
})
export class ProductItemComponent implements OnInit {
  imageUrl = environment.url;
  id: number;
  @Input() casno: string;
  product: Product;
  productImg: string;

  constructor(
    private productService: ProductService,
    private route: ActivatedRoute,
    private toastr: ToastrService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.route.params.subscribe((params) => {
      this.id = params['id'];
    });
    this.loadProductByCasNo();
  }

  loadProduct() {
    this.productService.getProductById(this.id).subscribe(response => {
      this.product = response;

      this.productImg = this.imageUrl + '/content/cas/' + this.product.casNo + '.png';

    })

  }

  loadProductByCasNo() {
    this.productService.getProductByCasNo(this.casno).subscribe(response => {
      this.product = response;

      this.productImg = this.imageUrl + '/content/cas/' + this.product.casNo + '.png';

    })

  }


  removeProduct(id) {
    this.productService.delete(id).subscribe(res => {
      this.toastr.success("产品已删除");
      this.router.navigateByUrl('/products')
    }, (error) => {
      this.toastr.error(error.error);
    })
  }

}
