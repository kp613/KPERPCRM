import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { IOurCompany } from '../ourcompany';
import { OurcompanyService } from '../ourcompany.service';

@Component({
  selector: 'app-ourcompany-list',
  templateUrl: './ourcompany-list.component.html',
  styleUrls: ['./ourcompany-list.component.scss']
})
export class OurcompanyListComponent implements OnInit {
  ourCompanies$: Observable<IOurCompany[]>;

  add: boolean = false;
  edit: boolean = false;
  detail: boolean = false;
  crudTitle: string;

  constructor(private ourcompanyService: OurcompanyService, private router: Router) { }

  ngOnInit(): void {
    this.loadOurCompanies();
  }

  loadOurCompanies() {
    this.ourCompanies$ = this.ourcompanyService.getOurCompanies();
  }

  addOurCompany() {
    this.router.navigate(["/settinghome/company/form"], {
      queryParams: {
        add: true,
        edit: false,
        detail: false,
        crudTitle: "增加新公司"
      }
    });
  }

  editOurCompany() {
    this.router.navigate(["/settinghome/company/form"], {
      queryParams: {
        add: false,
        edit: true,
        detail: false,
        crudTitle: "修改公司信息"
      }
    });
  }

  detailOurCompany() {
    this.router.navigate(["/settinghome/company/form"], {
      queryParams: {
        add: false,
        edit: false,
        detail: true,
        crudTitle: "公司信息"
      }
    });
  }

}
