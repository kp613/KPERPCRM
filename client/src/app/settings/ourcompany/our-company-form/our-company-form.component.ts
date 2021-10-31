import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { IOurCompany } from '../ourcompany';

@Component({
  selector: 'app-our-company-form',
  templateUrl: './our-company-form.component.html',
  styleUrls: ['./our-company-form.component.scss']
})
export class OurCompanyFormComponent implements OnInit {
  ourCompany: IOurCompany;
  setOurCompanyForm: FormGroup;

  crudTitle: string;
  add: boolean;
  edit: boolean;
  detail: boolean;

  fb: any;
  ourcompanyService: any;
  constructor(private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.queryParams.subscribe(params => {
      this.add = params.add;
      this.edit = params.edit;
      this.detail = params.detail;
      this.crudTitle = params.crudTitle
    });
  }


  ourCompanyForm() {
    this.setOurCompanyForm = this.fb.group({
      id: ['', [Validators.required]],
      companyName: ['', [Validators.required]],
      juridicalPerson: [''],
      registeredCapital: [''],
      paidInCapital: [''],
      shareTotal: [''],
      serviceFeature: [''],
      abbr: [''],
      web: [''],
      email: ['', [Validators.email]],
      regAddress: [''],
      regTel: [''],
      taxNumber: [''],
      bankName: [''],
      bankAccount: [''],
      bankAddress: [''],
      swiftCode: [''],
      otherInf: [''],
      officeAddress: [''],
      constitution: [''],
      stockComment: ['']
    })
  }

  onSaveForm() {
    this.ourcompanyService.addOurCompany
  }

  resetOurCompany() {
    this.setOurCompanyForm.reset();
  }



}
