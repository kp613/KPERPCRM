import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { IOurCompany } from './ourcompany';

@Injectable({
  providedIn: 'root'
})
export class OurcompanyService {
  baseUrl = environment.apiUrl;
  ourCompanies: IOurCompany[] = [];

  constructor(private httpClient: HttpClient) { }

  getOurCompanies(): Observable<IOurCompany[]> {
    return this.httpClient.get<IOurCompany[]>(this.baseUrl + "/OurCompanies");
  }

  addOurCompany(data: any) {
    return this.httpClient.post(this.baseUrl + "/OurCompanies", data);
  }

}
