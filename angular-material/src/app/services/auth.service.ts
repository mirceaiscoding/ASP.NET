import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { AuthModel } from '../interfaces/auth-model';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private baseUrl: string = environment.baseUrl;

  private privateHttpHeaders = {
    headers: new HttpHeaders({
      'content-type': 'application/json'
    })
  };

  private registerPrivateHttpHeaders = {
    headers: new HttpHeaders({
      'content-type': 'application/json',
      'response-type': 'text'
    })
  };

  constructor(private http: HttpClient) { }

  login(authModel: AuthModel){
    return this.http.post(
      this.baseUrl + 'login',
      authModel,
      this.privateHttpHeaders
    );
  }

  // You can only register as a pacient from the website
  register(authModel: AuthModel){
    type RegisterModel = AuthModel & {role: string}
    var registerModel: RegisterModel = {
      email: authModel.email,
      password: authModel.password,
      role: 'Pacient'
    };
    console.log(registerModel);
    return this.http.post(
      this.baseUrl + 'register',
      registerModel,
      this.registerPrivateHttpHeaders
    );
  }
}
