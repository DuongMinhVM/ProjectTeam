import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';

export const appRoutes: Routes = [
  {
    path: 'user',
    loadChildren: './modules/user-modules/user.module#UserModule'
  },
  {
    path: 'shop',
    loadChildren: './modules//shop-modules/shop.module#ShopModule'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(appRoutes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
