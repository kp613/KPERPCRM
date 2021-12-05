import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { environment } from 'src/environments/environment';
import { IProduct } from './product';
import { map } from 'rxjs/operators';
import { identifierModuleUrl } from '@angular/compiler';
import { ProductParams } from './productParams';
import { getPaginatedResult, getPaginationHeaders } from '../_core/pagination/paginationHelper';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  baseUrl = environment.apiUrl;
  // baseUrl = environment.apiUrlVer2;
  // imageUrl = environment.url;
  products: IProduct[] = [];
  productCache = new Map();
  productParams: ProductParams;


  constructor(private httpClient: HttpClient) {
    this.productParams = new ProductParams();
  }

  getProductParams() {
    return this.productParams;
  }

  setProductParams(params: ProductParams) {
    // console.log(params);
    this.productParams = params;
  }

  getProducts(productParams: ProductParams) {
    // this.productParams = new ProductParams();

    var response = this.productCache.get(Object.values(productParams).join('-'));
    if (response) {
      return of(response);
    };

    let params = getPaginationHeaders(productParams.pageNumber, productParams.pageSize);

    params = params.append('orderby', productParams.orderBy);

    return getPaginatedResult<IProduct[]>(this.baseUrl + "/products/lists/", params, this.httpClient).pipe(map(response => {
      this.productCache.set(Object.values(productParams).join('-'), response);
      return response;
    }))
  }

  // getProducts(): Observable<IProduct[]> {
  //   if (this.products.length > 0) return of(this.products);
  //   return this.httpClient.get<IProduct[]>(this.baseUrl + "/products/lists").pipe(
  //     map(products => {
  //       this.products = products;
  //       return products;
  //     })
  //   )
  //   // return this.httpClient.get<Product[]>(this.baseUrl + "/products");
  // }

  // getProducts(params: any): Observable<any> {
  //   return this.httpClient.get<any>(this.baseUrl + "/products/lists", { params });
  // }

  // getProductByCasNo(casno): Observable<any> {
  //   return this.httpClient.get(`${this.baseUrl + "/products"}/${casno}`);
  // }

  getProductByCasNo(casno): Observable<any> {
    // return this.httpClient.get(this.baseUrl + "/products" + "/edit");
    return this.httpClient.get(this.baseUrl + "/products/" + `${casno}`);
  }

  getProductById(id): Observable<any> {
    return this.httpClient.get(this.baseUrl + "/products/edit/" + id);
    // return this.httpClient.get(this.baseUrl + "/products/" + `${id}`);
  }

  create(data: any) {
    return this.httpClient.post(this.baseUrl + "/products/add", data);
  }

  update(id, data): Observable<any> {
    return this.httpClient.put(this.baseUrl + "/products/" + id, data);
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

  postFile(id, fileToUpload: File) {
    const formData: FormData = new FormData();
    formData.append('Image', fileToUpload, fileToUpload.name);
    return this.httpClient.patch(this.baseUrl + "/products/imageUpload" + id, fileToUpload)
  }
}
