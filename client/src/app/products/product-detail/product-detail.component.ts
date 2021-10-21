import { Component, Input, OnInit, Output, ViewChild } from '@angular/core';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { environment } from 'src/environments/environment';
import { IProduct } from '../product';
import { ProductItemComponent } from '../product-item/product-item.component';
import { ProductService } from '../product.service';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.scss']
})
export class ProductDetailComponent implements OnInit {
  getCasno: string;
  product: IProduct;
  // productId: number;
  @ViewChild('imgtest') productImg: string;

  constructor(private route: ActivatedRoute, private productService: ProductService, private toastr: ToastrService) { }

  ngOnInit(): void {
    this.getCasNo();
    // this.getProductId();
  }

  getCasNo() {
    return this.getCasno = this.route.snapshot.params['casno'];
  }

  // getProductId() {
  //   this.productService.getProductByCasNo(this.getCasno).subscribe(res => {
  //     this.product = res;
  //     this.productId = this.product.id;
  //   }, (error) => {
  //     this.toastr.error(error.error);
  //   })
  // }
}
