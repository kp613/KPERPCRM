import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { IProduct } from 'src/app/products/product';
import { environment } from 'src/environments/environment';
import { ProductService } from '../product.service';

@Component({
  selector: 'app-product-card',
  templateUrl: './product-card.component.html',
  styleUrls: ['./product-card.component.scss']
})
export class ProductCardComponent implements OnInit {
  @Input() product: IProduct;
  // baseUrl = environment.apiUrl;
  imageUrl = environment.url;

  constructor(
    private productService: ProductService,
    private toastr: ToastrService,
    private route: ActivatedRoute
  ) { }

  ngOnInit(): void {
  }

  // removeProduct(id) {
  //   this.productService.delete(id).subscribe(res => {
  //     this.toastr.success("产品已删除");
  //   }, (error) => {
  //     this.toastr.error(error.error);
  //   })
  // }

}
