import { HttpClient } from '@angular/common/http';
import { Component, Input, OnInit, Output } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { environment } from 'src/environments/environment';
import { Product } from '../product';
import { ProductService } from '../product.service';

@Component({
  selector: 'app-product-item',
  templateUrl: './product-item.component.html',
  styleUrls: ['./product-item.component.scss']
})
export class ProductItemComponent implements OnInit {
  imageUrl = environment.url;
  @Input() casno: string;
  product: Product;
  productImg: string;

  constructor(private productservice: ProductService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.loadProduct();
  }

  loadProduct() {
    this.productservice.getProductByCasNo(this.casno).subscribe(response => {
      this.product = response;

      this.productImg = this.imageUrl + '/content/cas/' + this.product.casNo + '.png';

    })

  }


}
