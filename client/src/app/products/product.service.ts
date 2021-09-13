import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Product } from './product';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  baseUrl = environment.apiUrl
  products: Product[] = [];

  constructor(private httpClient: HttpClient) { }

  readAll(): Observable<Product[]> {
    if (this.products.length > 0) return of(this.products);
    return this.httpClient.get<Product[]>(this.baseUrl + "api/products").pipe(
      map(products => {
        this.products = products;
        return products;
      })
    )
    // return this.httpClient.get<Product[]>(this.baseURL + "api/products");
  }

  read(id): Observable<any> {
    return this.httpClient.get(`${this.baseUrl + "api/products"}/${id}`);
  }

  create(data: any) {
    return this.httpClient.post(this.baseUrl + "api/products/add", data);
  }

  update(id, data): Observable<any> {
    return this.httpClient.put(`${this.baseUrl + "api/products"}/${id}`, data);
  }

  delete(id): Observable<any> {
    return this.httpClient.delete(`${this.baseUrl + "api/products"}/${id}`);
  }

  // deleteAll(): Observable<any> {
  //   return this.httpClient.delete(this.baseUrl + "api/products");
  // }

  searchByName(name): Observable<any> {
    return this.httpClient.get(`${this.baseUrl + "api/products"}?name=${name}`);
  }
}
