import { Injectable } from '@angular/core';
import {
  HttpInterceptor,
  HttpRequest,
  HttpErrorResponse,
  HttpHandler,
  HttpEvent,
  HttpResponse
} from '@angular/common/http';

import { Observable, EMPTY, throwError, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { environment } from 'src/environments/environment';
@Injectable()
export class ErrorInterceptor implements HttpInterceptor {

  constructor(private router: Router, private authService: AuthService) { }

  addAuthorizationHeader(request: HttpRequest<unknown>) {
    const token = localStorage.getItem("accessToken");
    request = request.clone({
      setHeaders: { Authorization: `Bearer ${token}` }
    });
    console.log("Added Authorization Header", request);
    return request;
  }

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    return next.handle(request).pipe(
      catchError((error: HttpErrorResponse) => {
        if (error.error instanceof Error) {
          // A client-side or network error occurred. Handle it accordingly.
          console.error('An error occurred:', error.error.message);
        } else {
          // If request is to the api
          const isApiUrl: boolean = request.url.startsWith(environment.baseUrl);
          if (isApiUrl && error.status == 401) {   // Unauthorized. Adding Authorization Header
            
            var token = localStorage.getItem('accessToken');
            if (token === null) {
              console.log("No token in local storage");
              return EMPTY;
            }
        
            if (this.authService.isTokenExpired(token)) {
              // Refresh token
              console.log("Token is expired.");
              this.authService.refreshToken().subscribe((response: any) => {
                console.log(response);
                if (response['success']) {
                  var newToken = response['newAccessToken']
                  console.log("New token", newToken);
                  localStorage.setItem('accessToken', newToken);

                  // Try again but with authorization
                  request = this.addAuthorizationHeader(request);
                  return next.handle(request); 

                } else {
                  console.log("Failed to refresh token!");
                  this.authService.logout();
                  return EMPTY;
                }
              });
            } else {
              // Try again but with authorization
              request = this.addAuthorizationHeader(request);
              return next.handle(request); 
            }
          }

          if (error.status == 500) {
            this.router.navigate(["login"]);
          }
        }
        // The backend returned an unsuccessful response code.
        console.error(`Backend returned code ${error.status}, body was: ${error.error}`);
        return EMPTY;
      })
    );
  }
}
