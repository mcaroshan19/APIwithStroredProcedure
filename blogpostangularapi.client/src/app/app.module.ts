import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './Featured/navbar/navbar.component';
import { HomeComponent } from './Featured/home/home.component';
import { AddCategoryComponent } from './Core/add-category/add-category.component';
import { AddCategoryListComponent } from './Core/add-category-list/add-category-list.component';
import { FormsModule } from '@angular/forms';
@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    HomeComponent,
    AddCategoryComponent,
    AddCategoryListComponent,
    
  ],
  imports: [
    BrowserModule, HttpClientModule,
    AppRoutingModule,
    FormsModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
