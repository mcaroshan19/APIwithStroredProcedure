import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddCategoryListComponent } from './Core/add-category-list/add-category-list.component';
import { AddCategoryComponent } from './Core/add-category/add-category.component';
import { HomeComponent } from './Featured/home/home.component';


const routes: Routes = [

  {
    path: 'add-category-list',
    component: AddCategoryListComponent,
  
  }, 
  {
    path:'home' ,
    component: HomeComponent,
  },
  {
    path:'add-category',
    component: AddCategoryComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
