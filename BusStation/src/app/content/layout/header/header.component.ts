import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/core/account/auth-service';
import { TripReportParameters } from 'src/app/core/models/utility/trip-report-parameters';
import { TripReportService } from 'src/app/core/services/trip-report.sevice';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  private tripReportParameters: TripReportParameters={
    pageNumber: 1,
  }

  constructor(
    public authService: AuthService,
    private tripReportService: TripReportService) { }

  ngOnInit(): void { }

  logout() {
    this.authService.logout();
  }

  getTripReports(){
    console.log(1);
    this.tripReportService.getReportAboutAllTrips(this.tripReportParameters).subscribe(res =>
    console.log(res)
    );
  }
}
