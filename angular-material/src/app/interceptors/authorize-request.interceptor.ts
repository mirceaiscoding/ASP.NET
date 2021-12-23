import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { AuthService } from '../services/auth.service';

@Injectable()
export class AuthorizeRequestInterceptor implements HttpInterceptor {

  constructor(private authService: AuthService) {}

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    // add auth header with jwt if account is logged in and request is to the api url
    const token = localStorage.getItem("accessToken");
    const isApiUrl: boolean = request.url.startsWith(environment.baseUrl);
    if (token != null && isApiUrl) {
      console.log("Intercepted request. Adding Authorization Header");
      request = request.clone({
            setHeaders: { Authorization: `Bearer ${token}` }
        });
    }
    return next.handle(request);
  }
}
