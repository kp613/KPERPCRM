import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Product } from '../_models/product';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {
  baseUrl = environment.apiUrl

  constructor(private httpClient: HttpClient) {

  }

  getProductsList(): Observable<Product[]> {
    return this.httpClient.get<Product[]>(this.baseUrl + "api/products")
  }

  insertProduct(newProduct: Product): Observable<Product> {
    return this.httpClient.post<Product>(this.baseUrl + "api/products", newProduct);
  }

}

