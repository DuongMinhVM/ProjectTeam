import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShopComponent } from './shop.component';
import { RouterModule } from '@angular/router';
import { shopRoutes } from './shop.route';
import { HttpClientModule } from '@angular/common/http';
import { SweetAlert2Module } from '@toverux/ngx-sweetalert2';

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(shopRoutes),
    HttpClientModule,
    SweetAlert2Module.forRoot()
  ],
  exports: [
    RouterModule
  ],
  declarations: [ShopComponent]
})
export class ShopModule { }
