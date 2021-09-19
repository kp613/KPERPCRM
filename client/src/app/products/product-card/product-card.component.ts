import { Component, Input, OnInit } from '@angular/core';
import { Product } from 'src/app/products/product';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-product-card',
  templateUrl: './product-card.component.html',
  styleUrls: ['./product-card.component.scss']
})
export class ProductCardComponent implements OnInit {
  @Input() product: Product;
  baseUrl = environment.apiUrl;

  constructor() { }

  ngOnInit(): void {
  }

}
