import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomePageComponent } from './content/pages/home-page/home-page.component';
import { TripReportPageComponent } from './content/pages/trip-report-page/trip-report-page.component';
import { SignInPageComponent } from './content/pages/sign-in-page/sign-in-page.component';
import { SignUpPageComponent } from './content/pages/sign-up-page/sign-up-page.component';
import { ManagementPageComponent } from './content/pages/management-page/management-page.component';
import { BusesComponent } from './content/pages/management-page/buses/buses.component';

const routes: Routes = [
  { path: "", component: TripReportPageComponent },
  { path: "home", component: HomePageComponent },
  { path: "signin", component: SignInPageComponent },
  { path: "signup", component: SignUpPageComponent },
  { path: "management", component:ManagementPageComponent },
  { path: "management/buses", component:BusesComponent },
  { path: "user", loadChildren: () => import("./content/pages/pages.module").then(p => p.PagesModule) },
  { path: "**", redirectTo: "", pathMatch: "full" }];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
