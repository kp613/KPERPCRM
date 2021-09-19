import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrModule, ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { ILoggedUser } from 'src/app/account/loggedUser';
import { AccountService } from 'src/app/account/account.service';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  @Output() wantRegister = new EventEmitter();
  loginForm: FormGroup;

  // model: any = {}
  currentUser$: Observable<ILoggedUser>;

  constructor(private accountService: AccountService, private router: Router, private toastr: ToastrService) { }

  ngOnInit(): void {
    this.currentUser$ = this.accountService.currentUser$;
    this.createLoginForm();
  }

  createLoginForm() {
    this.loginForm = new FormGroup({
      username: new FormControl('', Validators.required),
      password: new FormControl('', Validators.required),
    })
  }

  // login() {
  //   this.accountService.login(this.model).subscribe(response => {
  //     this.router.navigateByUrl('/dashboard')
  //   }, error => {
  //     console.log(error);
  //     this.toastr.error(error.error)
  //   })
  // }

  login() {
    this.accountService.login(this.loginForm.value).subscribe(response => {
      this.router.navigateByUrl('/dashboard')
    }, error => {
      console.log(error);
      this.toastr.error(error.error)
    })
  }

  logout() {
    this.accountService.logout();
    this.router.navigateByUrl('/')
  }

  cancel() {
    console.log('canceled')
  }

  register() {
    this.wantRegister.emit(true);
  }
}
