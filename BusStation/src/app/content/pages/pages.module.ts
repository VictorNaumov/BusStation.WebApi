import { NgModule } from '@angular/core';
import { PagesRoutingModule } from './pages-routing-module';
import { PagesComponent } from './pages.component';
import { CommonModule } from '@angular/common';
import { LoadingModule } from '../layout/loading/loading.module';
import { SignInPageComponent } from './sign-in-page/sign-in-page.component';
import { SignUpPageComponent } from './sign-up-page/sign-up-page.component';
import { HomePageComponent } from './home-page/home-page.component';

@NgModule({
  declarations: [
    PagesComponent,
    SignInPageComponent,
    SignUpPageComponent,
    HomePageComponent,
  ],
  imports: [
    CommonModule,
    PagesRoutingModule,
    LoadingModule,
  ],
  exports: [
    PagesComponent
  ],
  providers: []
})
export class PagesModule { }
