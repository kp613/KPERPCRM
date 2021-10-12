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
  // baseUrl = environment.apiUrl;
  baseUrl = environment.apiUrlVer2;
  // imageUrl = environment.url;
  products: Product[] = [];


  constructor(private httpClient: HttpClient) { }

  readAll(): Observable<Product[]> {
    if (this.products.length > 0) return of(this.products);
    return this.httpClient.get<Product[]>(this.baseUrl + "/products").pipe(
      map(products => {
        this.products = products;
        return products;
      })
    )
    // return this.httpClient.get<Product[]>(this.baseURL + "products");
  }

  // getProductByCasNo(casno): Observable<any> {
  //   return this.httpClient.get(`${this.baseUrl + "/products"}/${casno}`);
  // }

  getProductByCasNo(casno): Observable<any> {
    return this.httpClient.get(this.baseUrl + "/products" + "/" + `${casno}`);
  }

  create(data: any) {
    return this.httpClient.post(this.baseUrl + "/products/add", data);
  }

  update(id, data): Observable<any> {
    return this.httpClient.put(`${this.baseUrl + "/products"}/${id}`, data);
  }

  delete(id): Observable<any> {
    return this.httpClient.delete(`${this.baseUrl + "/products"}/${id}`);
  }

  // deleteAll(): Observable<any> {
  //   return this.httpClient.delete(this.baseUrl + "products");
  // }

  searchByName(name): Observable<any> {
    return this.httpClient.get(`${this.baseUrl + "/products"}?name=${name}`);
  }


}
