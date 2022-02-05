import { NgModule } from '@angular/core';
import { PagesRoutingModule } from './pages-routing-module';
import { PagesComponent } from './pages.component';
import { CommonModule } from '@angular/common';
import { LoadingModule } from '../layout/loading/loading.module';
import { SignInPageComponent } from './sign-in-page/sign-in-page.component';
import { SignUpPageComponent } from './sign-up-page/sign-up-page.component';
import { HomePageComponent } from './home-page/home-page.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { TripReportPageComponent } from './trip-report-page/trip-report-page.component';
import { ManagementPageComponent } from './management-page/management-page.component';
import { BusesComponent } from './management-page/buses/buses.component';
import { RoutesComponent } from './management-page/routes/routes.component';
import { BusStopsComponent } from './management-page/bus-stops/bus-stops.component';
import { RouteBusStopsComponent } from './management-page/route-bus-stops/route-bus-stops.component';
import { TripsComponent } from './management-page/trips/trips.component';

@NgModule({
  declarations: [
    PagesComponent,
    SignInPageComponent,
    SignUpPageComponent,
    HomePageComponent,
    TripReportPageComponent,
    ManagementPageComponent,
    BusesComponent,
    RoutesComponent,
    BusStopsComponent,
    RouteBusStopsComponent,
    TripsComponent
  ],
  imports: [
    CommonModule,
    PagesRoutingModule,
    LoadingModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule
    ],
  exports: [
    PagesComponent
  ],
  providers: []
})
export class PagesModule { }
