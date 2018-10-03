import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserComponent } from './user.component';
import { LoginComponent } from './login/login.component';
import { RouterModule } from '@angular/router';
import { userRoutes } from './user.routes';
import { ReactiveFormsModule } from '@angular/forms';
import { SweetAlert2Module } from '@toverux/ngx-sweetalert2';
import { HttpClientModule } from '@angular/common/http';
import { UserService } from '../../shared/services/user.service';

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(userRoutes),
    HttpClientModule,
    ReactiveFormsModule,
    SweetAlert2Module.forRoot()
  ],
  exports: [RouterModule],
  declarations: [UserComponent, LoginComponent],
  providers: [UserService]
})
export class UserModule {}
