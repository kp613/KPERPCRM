import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { IOurCompany } from './ourcompany';
import { OurcompanyService } from './ourcompany.service';

@Component({
  selector: 'app-ourcompany',
  templateUrl: './ourcompany.component.html',
  styleUrls: ['./ourcompany.component.scss']
})
export class OurcompanyComponent implements OnInit {
  ourCompanies$: Observable<IOurCompany[]>;

  constructor(private ourcompanyService: OurcompanyService) { }

  ngOnInit(): void {
    this.loadOurCompanies();
  }

  loadOurCompanies() {
    this.ourCompanies$ = this.ourcompanyService.getOurCompanies();
  }

}
