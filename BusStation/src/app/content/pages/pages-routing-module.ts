import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { AuthGuard } from "src/app/core/guards/auth.guard";
import { PagesComponent } from "./pages.component";
import { SignInPageComponent } from "./sign-in-page/sign-in-page.component";

const routes: Routes = [
    {
        path: "",
        component: PagesComponent,
        children: [
            { path: "signin", component: SignInPageComponent },
        ],
        // canActivate: [AuthGuard]
    },
    {
        path: "**",
        redirectTo: "home",
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes), CommonModule],
    exports: [RouterModule],
    providers: [AuthGuard]
})
export class PagesRoutingModule { }
