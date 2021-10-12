import { Component, Input, OnInit, Output, ViewChild } from '@angular/core';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { environment } from 'src/environments/environment';
import { Product } from '../product';
import { ProductItemComponent } from '../product-item/product-item.component';
import { ProductService } from '../product.service';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.scss']
})
export class ProductDetailComponent implements OnInit {
  getCasno: string;
  @ViewChild('imgtest') productImg: string;

  constructor(private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.getCasNo();
  }

  getCasNo() {
    return this.getCasno = this.route.snapshot.params['casno'];
  }
}
