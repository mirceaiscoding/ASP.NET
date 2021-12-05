import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, ValidationErrors, ValidatorFn, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthModel } from 'src/app/interfaces/auth-model';
import { AuthService } from 'src/app/services/auth.service';
import { CustomErrorStateMatcher } from 'src/app/utils/custom-error-state-matcher';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  constructor(private authService: AuthService,
    private router: Router) { }

  emailRegx = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
  passwordRegx = /(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[^A-Za-z0-9])(?=.{8,})/

  // Checks that the password matches the confirmedPassword
  checkPasswords: ValidatorFn = (group: AbstractControl):  ValidationErrors | null => { 
    let password = group.get('password')!.value;
    let confirmedPassword = group.get('confirmedPassword')!.value;
    return password === confirmedPassword ? null : { notSame: true }
  }

  customErrorStateMatcher = new CustomErrorStateMatcher();

  loginForm = new FormGroup({
    email: new FormControl('', [Validators.required, Validators.pattern(this.emailRegx)]),
    password: new FormControl('', [Validators.required, Validators.pattern(this.passwordRegx)]),
    confirmedPassword: new FormControl('', Validators.required)
  }, {validators: this.checkPasswords});

  ngOnInit(): void { }

  goToLoginPage() {
    this.router.navigate(['/login'])
  }

  // Submits login form
  submit() {
    if (!this.loginForm.valid) {
      console.log("Invalid form!");
      return;
    }
    var loginData: AuthModel = this.loginForm.value;
    console.log(loginData);

    // Call auth service
    this.authService.register(loginData).subscribe((response: any) => {
      console.log(response);
      if (response == true) {
        this.router.navigate(['/login']);
      } else {
        alert("Email already used by another account!");
      }
    });
  }


}
