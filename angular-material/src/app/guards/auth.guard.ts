import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { catchError, map, Observable } from 'rxjs';
import { AuthService } from '../services/auth.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private auth: AuthService, private router: Router) { }

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    console.log("Called AuthGuard");
    if (!this.auth.isLoggedIn()) {
      this.router.navigate(["login"]);
      return false;
    }
    // Try to refresh to see if it's still valid
    return this.auth.refreshToken().pipe(map((response: any) => {
      if (response["success"]) return true;
      this.router.navigate(["login"]);
      return false;
    }));
  }
}
