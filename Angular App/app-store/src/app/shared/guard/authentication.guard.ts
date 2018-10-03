import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { UserService } from '../services/user.service';

@Injectable()
export class AuthenticationCanActiveGuard implements CanActivate {

  constructor(private userService: UserService, private router: Router) {

  }

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): Observable<boolean> | Promise<boolean> | boolean {
      const token = localStorage.getItem(environment.keyToken);
      if (!token) {
        this.router.navigate(['/user/login']);
        return false;
      }
      return true;
  }
}
