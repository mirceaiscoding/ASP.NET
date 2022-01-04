import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthModel } from 'src/app/interfaces/auth-model';
import { AuthService } from 'src/app/services/auth.service';
import { FormControl, FormGroup, FormBuilder, Validators } from '@angular/forms';
import { JwtHelperService } from '@auth0/angular-jwt';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private authService: AuthService,
    private router: Router,
    private jwtHelper: JwtHelperService) { }

  emailRegx = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;

  loginForm = new FormGroup({
    email: new FormControl('', [Validators.required, Validators.pattern(this.emailRegx)]),
    password: new FormControl('', Validators.required)
  });

  ngOnInit(): void { }

  goToRegisterPage() {
    this.router.navigate(['/register'])
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
    this.authService.login(loginData).subscribe((response: any) => {
      console.log(response);
      if (response && response['accessToken'] && response['refreshToken']) {
        localStorage.setItem('accessToken', response['accessToken']);
        localStorage.setItem('refreshToken', response['refreshToken']);
        var role = this.jwtHelper.decodeToken(response['accessToken'])['role'];
        localStorage.setItem('role', role)
        this.router.navigate(['dashboard']);
      } else {
        alert(response['message']);
      }
    });
  }

}
