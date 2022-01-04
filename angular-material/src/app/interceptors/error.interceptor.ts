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

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    return next.handle(request).pipe(
      catchError((error: HttpErrorResponse) => {
        if (error.error instanceof Error) {
          // A client-side or network error occurred. Handle it accordingly.
          console.error('An error occurred:', error.error.message);
        } else {
          if (error.status == 401) {   // Unauthorized. Adding Authorization Header
            
            // Refresh token if it is expired
            var isAuthentificated = this.authService.isAuthenticatedRefreshToken();

            // If request is to the api
            const isApiUrl: boolean = request.url.startsWith(environment.baseUrl);

            if (isAuthentificated && isApiUrl) {
              const token = localStorage.getItem("accessToken");
              request = request.clone({
                setHeaders: { Authorization: `Bearer ${token}` }
              });
              console.log("Added Authorization Header", request);
              return next.handle(request);  // Try again but with authorization
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
