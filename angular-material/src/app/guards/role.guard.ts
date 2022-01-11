import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from '../services/auth.service';

@Injectable({
  providedIn: 'root'
})
export class RoleGuard implements CanActivate {

  constructor(private authService: AuthService){}

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    var acceptedRoles = route.data["roles"] as Array<string>;
    var role = this.authService.getRole();
    console.log("Accepted roles", acceptedRoles);
    console.log("Current role", role);
    return acceptedRoles.findIndex(x => x.valueOf() == role.valueOf()) != -1;
  }
  
}
