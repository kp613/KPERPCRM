import { Component, Input, OnInit, Output } from '@angular/core';
import { Product } from '../product';


@Component({
  selector: 'app-product-form',
  templateUrl: './product-form.component.html',
  styleUrls: ['./product-form.component.scss']
})
export class ProductFormComponent implements OnInit {
  @Input() product: Product[] = [];


  constructor() { }

  ngOnInit(): void {
  }

}
