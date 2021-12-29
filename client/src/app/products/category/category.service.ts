import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ICategoryFirst } from './category-first/categoryFirst';
import { ICategorySecond } from './category-second/categorySecond';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  baseUrl = environment.apiUrl;

  categoryFirst = new Subject<any>();

  categoryFirst$ = this.categoryFirst.asObservable();

  constructor(private httpClient: HttpClient) { }

  //Get firstId and secondId
  // setCategoryFirst(value: any) {
  //   this.categoryFirst.next(value);
  // }


  //First
  getFirstLists(): Observable<ICategoryFirst[]> {
    return this.httpClient.get<ICategoryFirst[]>(this.baseUrl + "/Category/First");
  }

  getFirstById(id): Observable<any> {
    return this.httpClient.get(this.baseUrl + "/Category/First/" + id);
  }

  firstCreate(data: any) {
    return this.httpClient.post(this.baseUrl + "/Category/first", data);
  }

  firstUpdate(id, data): Observable<any> {
    return this.httpClient.put(this.baseUrl + "/Category/First/" + id, data);
  }

  firstDelete(id): Observable<any> {
    return this.httpClient.delete(`${this.baseUrl + "/Category/First"}/${id}`);
  }

  //Second
  getSecondLists(firstId): Observable<ICategorySecond[]> {
    return this.httpClient.get<ICategorySecond[]>(this.baseUrl + "/Category/Second/" + firstId);
  }

  getSecondById(id): Observable<any> {
    return this.httpClient.get(this.baseUrl + "/Category/Second/" + id);
  }

  secondCreate(data: any) {
    return this.httpClient.post(this.baseUrl + "/Category/Second", data);
  }

  secondUpdate(id, data): Observable<any> {
    return this.httpClient.put(this.baseUrl + "/Category/Second/" + id, data);
  }

  secondDelete(id): Observable<any> {
    return this.httpClient.delete(`${this.baseUrl + "/Category/Second"}/${id}`);
  }

  //Third


}
