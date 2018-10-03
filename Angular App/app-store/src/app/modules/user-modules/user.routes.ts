import { Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
// import { AuthenticationCanActiveGuard } from '../../shared/guard/authentication.guard';


export const userRoutes: Routes = [
  {
    path: 'login',
    component: LoginComponent
  },
  {
    path: 'register',
    component: null
  }
];
