import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [{ path: 'list', loadChildren: () => import('./pages/products/list/list.module').then(m => m.ListModule) }, 
{ path: 'add', loadChildren: () => import('./pages/products/new/new.module').then(m => m.NewModule) }, 
{ path: 'details/:id', loadChildren: () => import('./pages/products/details/details.module').then(m => m.DetailsModule) }, 
{ path: 'edit', loadChildren: () => import('./pages/products/edit/edit.module').then(m => m.EditModule) },  ];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
