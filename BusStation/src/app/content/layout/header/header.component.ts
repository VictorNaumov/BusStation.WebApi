import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/core/account/auth-service';
import { TripReportParameters } from 'src/app/core/models/utility/trip-report-parameters';
import { NotificationService } from 'src/app/core/services/notification-service';
import { TripReportService } from 'src/app/core/services/trip-report.sevice';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  private tripReportParameters: TripReportParameters={
    pageNumber: 1,
  }

  constructor(
    public authService: AuthService,
    public notificationService: NotificationService,
    private tripReportService: TripReportService) { }

  ngOnInit(): void { }

  logout() {
    this.authService.logout();
  }

  getTripReports(){
    this.tripReportService.getReportAboutAllTrips(this.tripReportParameters).subscribe(res =>
    console.log(res)
    );

    this.notificationService.ErrorNotice('suck');
  }
}
