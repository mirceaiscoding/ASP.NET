import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, ValidationErrors, ValidatorFn, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { AuthModel } from 'src/app/interfaces/auth-model';
import { PacientModel } from 'src/app/interfaces/pacient-model';
import { PacientRegistrationModel } from 'src/app/interfaces/pacient-registration-model';
import { AuthService } from 'src/app/services/auth.service';
import { CustomErrorStateMatcher } from 'src/app/utils/custom-error-state-matcher';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  constructor(private authService: AuthService,
    private router: Router,
    private jwtHelper: JwtHelperService) { }

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
    firstName: new FormControl('', [Validators.required]),
    lastName: new FormControl('', [Validators.required]),
    phoneNumber: new FormControl('', []),
    dateOfBirth: new FormControl('', [Validators.required]),
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
    var formData = this.loginForm.value;
    var pacientData: PacientModel = {
      firstName: formData.firstName,
      lastName: formData.lastName,
      phoneNumber: formData.phoneNumber,
      dateOfBirth: formData.dateOfBirth
    };
    var loginData: AuthModel = {
      email: formData.email,
      password: formData.password
    };
    var registerData: PacientRegistrationModel = {
      registerModel: loginData,
      pacientDTO: pacientData
    };
    console.log(registerData);

    // Call auth service
    this.authService.registerAsPacient(registerData).subscribe((response: any) => {
      console.log(response);
      if (response == true) {
        this.authService.login(loginData).subscribe((response: any) => {
          console.log(response);
          if (response && response['accessToken'] && response['refreshToken']) {
            localStorage.setItem('accessToken', response['accessToken']);
            localStorage.setItem('refreshToken', response['refreshToken']);
            var role = this.jwtHelper.decodeToken(response['accessToken'])['role'];
            localStorage.setItem('role', role)
            this.router.navigate(['/home']);
          } else {
            alert(response['message']);
          }
        });
      } else {
        alert("Email already used by another account!");
      }
    });
  }


}
