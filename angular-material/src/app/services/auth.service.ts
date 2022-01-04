import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { environment } from 'src/environments/environment';
import { AuthModel } from '../interfaces/auth-model';
import { PacientRegistrationModel } from '../interfaces/pacient-registration-model';

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

  constructor(private http: HttpClient, private jwtHelper: JwtHelperService) { }

  public isAuthenticatedRefreshToken(): boolean {
    const token = localStorage.getItem('accessToken');
    if (token === null) {
      console.log("No token in local storage");
      return false;
    }

    var isTokenExpired = this.jwtHelper.isTokenExpired(token);

    if (!isTokenExpired) {
      console.log("Token already is valid");
      return true;
    }
    // Refresh token
    console.log("Token is expired.");
    this.refreshToken().subscribe((response: any) => {
      console.log(response);
      if (response['success']) {
        var newToken = response['newAccessToken']
        console.log("New token", newToken);
        localStorage.setItem('accessToken', newToken);
        return true;
      } else {
        console.log("Failed to refresh token!", newToken);
        this.logout();
        return false;
      }
    });
    return false;
  }

  login(authModel: AuthModel) {
    return this.http.post(
      this.baseUrl + 'login',
      authModel,
      this.privateHttpHeaders
    );
  }

  logout() {
    localStorage.removeItem("accessToken");
    localStorage.removeItem("refreshToken");
    localStorage.removeItem("role");
  }

  // You can only register as a pacient from the website
  registerAsPacient(pacientRegistrationModel: PacientRegistrationModel) {
    return this.http.post(
      this.baseUrl + 'register-as-pacient',
      pacientRegistrationModel,
      this.registerPrivateHttpHeaders
    );
  }

  refreshToken() {
    var currentToken = {
      "accessToken": localStorage.getItem('accessToken'),
      "refreshToken": localStorage.getItem('refreshToken')
    };

    return this.http.post(
      this.baseUrl + 'refresh',
      currentToken,
      this.privateHttpHeaders
    );
  }

  getRole(): string {
    const role = localStorage.getItem('role')
    if (role != null) {
      return role;
    }
    return ""
  }
}
