import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthModel } from 'src/app/interfaces/auth-model';
import { AuthService } from 'src/app/services/auth.service';
import { FormControl, FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private authService: AuthService,
    private router: Router,
    private formBuilder: FormBuilder) { }

  emailRegx = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;

  // loginForm: FormGroup = this.formBuilder.group({
  //   email: [null, [Validators.required, Validators.pattern(this.emailRegx)]],
  //   password: [null, Validators.required]
  // });

  loginForm = new FormGroup({
    email: new FormControl('', [Validators.required, Validators.pattern(this.emailRegx)]),
    password: new FormControl('', Validators.required)
  });

  ngOnInit() : void {}

  submit() {
    if (!this.loginForm.valid) {
      console.log("Invalid form!");
      return;
    }
    var loginData: AuthModel = this.loginForm.value;
    console.log(loginData);
    
    // if (this.validateEmail(this.user.email)) {
      // APELAM SERVICIU LOGIN
      // this.authService.login(this.user).subscribe((response: any) => {
      //   console.log(response);
      //   if (response && response.token) {
      //     localStorage.setItem('token', response.token);
      //     this.router.navigate(['/home']);
      //   }
      // });
    //   console.log("Login complete!");
    // } else {
    //   console.log("Email is not valid!");
    //   this.error = "Email is not valid!";
    // }
  }

}
