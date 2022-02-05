import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { AuthGuard } from "src/app/core/guards/auth.guard";
import { PagesComponent } from "./pages.component";
import { SignInPageComponent } from "./sign-in-page/sign-in-page.component";
import { ManagementPageComponent } from "./management-page/management-page.component";
import { HomePageComponent } from "./home-page/home-page.component";
import { AboutPageComponent } from "./about-page/about-page.component";
import { SignUpPageComponent } from "./sign-up-page/sign-up-page.component";
import { TripReportPageComponent } from "./trip-report-page/trip-report-page.component";
import { BusesComponent } from "./management-page/buses/buses.component";
import { BusStopsComponent } from "./management-page/bus-stops/bus-stops.component";
import { RoutesComponent } from "./management-page/routes/routes.component";
import { RouteBusStopsComponent } from "./management-page/route-bus-stops/route-bus-stops.component";
import { TripsComponent } from "./management-page/trips/trips.component";

const routes: Routes = [
  {
    path: "",
    component: PagesComponent,
    children: [
      { path: "", component: HomePageComponent },
      { path: "about", component: AboutPageComponent },
      { path: "signin", component: SignInPageComponent },
      { path: "signup", component: SignUpPageComponent },
      { path: "reports", component: TripReportPageComponent },
      {
        path: "management",
        component: ManagementPageComponent,
        children: [
          { path: "buses", component: BusesComponent },
          { path: "busStops", component: BusStopsComponent },
          { path: "routes", component: RoutesComponent },
          { path: "routeBusStops", component: RouteBusStopsComponent },
          { path: "trips", component: TripsComponent },
        ],
        canActivate: [AuthGuard]
      },
    ]
  },
  { path: "**", redirectTo: "", pathMatch: "full" }
];

@NgModule({
    imports: [RouterModule.forChild(routes), CommonModule],
    exports: [RouterModule],
    providers: [AuthGuard]
})
export class PagesRoutingModule { }
