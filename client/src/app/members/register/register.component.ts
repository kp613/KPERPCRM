import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, ValidatorFn, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { BsLocaleService } from 'ngx-bootstrap/datepicker';
import { ToastrService } from 'ngx-toastr';
import { AccountService } from 'src/app/_services/account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  @Output() cancelRegister = new EventEmitter();
  model: any = {};
  registerForm: FormGroup;
  maxDate: Date;
  validationErrors: string[] = [];

  constructor(public accountService: AccountService, private toastr: ToastrService, private fb: FormBuilder, private router: Router) {
  }

  ngOnInit(): void {
    this.initializeForm();
    this.maxDate = new Date();
    this.maxDate.setFullYear(this.maxDate.getFullYear() - 18);
  }

  initializeForm() {
    this.registerForm = this.fb.group({
      username: ['', Validators.required],
      knownAs: [''],
      email: ['', [Validators.required, Validators.email]],
      phoneNumber: ['', [Validators.required, Validators.pattern('([+][1-9]{1}[0-9]{0,2}){0,1}[0-9]{11}')]],
      name: ['', Validators.required],
      nationalId: ['', [Validators.required, Validators.pattern('^[1-9]{1}[0-9]{5}[1-2]{1}[0-9]{1}[0-9]{2}[0-1]{1}[0-9]{1}[0-3]{1}[0-9]{1}[0-9]{3}[0-9Xx]{1}$')]],
      dateOfBirth: ['', Validators.required],
      // password: ['', [Validators.required, Validators.minLength(6), Validators.pattern('^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{6,}$')]],
      password: ['', [Validators.required, Validators.minLength(6), Validators.maxLength(10), Validators.pattern('(?=^.{6,10}$)(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&amp;*()_+}{&gt;.&lt;,])(?!.*\\s).*$')]],
      confirmPassword: ['', [Validators.required, this.matchValues('password')]],
      gender: ['', Validators.required]
    })
  }

  matchValues(matchTo: string): ValidatorFn {
    return (control: AbstractControl) => {
      return control?.value === control?.parent?.controls[matchTo].value
        ? null : { isMatching: true }
    }
  }

  register() {
    // console.log(this.registerForm.value);

    this.accountService.register(this.registerForm.value).subscribe(response => {
      this.router.navigateByUrl('/member/edit');
      // this.validationErrors;
      ;
    })
  }


  cancel() {
    this.cancelRegister.emit(false);
  }

  // getBirthday(birthday: any) {
  //   var nationalId = this.registerForm.get('nationalId').value;
  //   if (nationalId != null && nationalId != "") {
  //     birthday = nationalId.replace(/(.{4})(.{2})/, "$1-$2-");
  //   }
  //   return birthday;
  // }

}
