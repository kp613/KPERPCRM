import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { finished } from 'stream';
import { IDesignRecord } from './design-recore';

@Injectable({
  providedIn: 'root'
})
export class DesignRecordService {
  id: number;
  baseUrl = environment.apiUrl;
  designRecords: IDesignRecord[] = [];

  crudRecords = [
    'List',
    'Created',
    'Read',
    'Updated',
    'Deleted',
    'Other'];

  folderNames = [
    'settings',
    'admin',
    'business',
    'products',
    'customers',
    'members',
    'account',
    'weblayout',
    '0 design book'
  ];

  constructor(private httpClient: HttpClient) { }

  getLists(): Observable<IDesignRecord[]> {
    return this.httpClient.get<IDesignRecord[]>(this.baseUrl + "/DesignRecord");
  }

  getRecordById(id): Observable<any> {
    return this.httpClient.get(this.baseUrl + "/DesignRecord/" + id);
  }

  setFinished(id): Observable<any> {
    return this.httpClient.patch(this.baseUrl + "/DesignRecord/patch/" + id, {});
  }

  create(data: any) {
    return this.httpClient.post(this.baseUrl + "/DesignRecord", data);
  }

  update(id, data): Observable<any> {
    return this.httpClient.put(this.baseUrl + "/DesignRecord/" + id, data);
  }

  delete(id): Observable<any> {
    return this.httpClient.delete(`${this.baseUrl + "/DesignRecord"}/${id}`);
  }

}
