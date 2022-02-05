import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { RouteTypeIncomingDTO } from 'src/app/core/models/incoming/route-type-incoming-dto';
import { ScheduleIncomingDTO } from 'src/app/core/models/incoming/schedule-incoming-dto';
import { TripReportIncomingDTO } from 'src/app/core/models/incoming/trip-report-incoming-dto';
import { TripReportParameters } from 'src/app/core/models/utility/trip-report-parameters';
import { RouteTypeService } from 'src/app/core/services/route-type.service';
import { ScheduleService } from 'src/app/core/services/schedule.service';
import { TripReportService } from 'src/app/core/services/trip-report.sevice';

@Component({
  selector: 'app-trip-report-page',
  templateUrl: './trip-report-page.component.html',
  styleUrls: ['./trip-report-page.component.scss']
})
export class TripReportPageComponent implements OnInit {
  isLoading:boolean = false;

  tripReportParameters: TripReportParameters = {
    pageNumber: 1,
  }

  public routeType$: Observable<RouteTypeIncomingDTO[]> | undefined;
  public schedule$: Observable<ScheduleIncomingDTO[]> | undefined;
  public tripReports: TripReportIncomingDTO[] = [];

  constructor(
    private routeTypeService: RouteTypeService,
    private scheduleService: ScheduleService,
    private tripReportService: TripReportService) { }

  ngOnInit(): void {
    this.getData();
    this.sendQuery();

  }

  onPageChange(page: number = 1): void {
    this.tripReportParameters.pageNumber = page;
    this.sendQuery();
  }

  getData(){
    this.routeType$ = this.routeTypeService.GetAllRouteTypes();
    this.schedule$ = this.scheduleService.GetAllSchedules();
  }

  sendQuery(){
    this.tripReportService.getReportAboutAllTrips(this.tripReportParameters).subscribe(tripReports => this.tripReports = tripReports);
  }

  search(){
    this.tripReportParameters.searchTerm = (<HTMLInputElement>document.getElementById('search')).value;
    this.onPageChange();
  }

  routeTypeChange(){
    this.tripReportParameters.routeType = (<HTMLInputElement>document.getElementById('routeType')).value;
    this.onPageChange();
  }

  scheduleChange(){
    this.tripReportParameters.schedule = (<HTMLInputElement>document.getElementById('schedule')).value;
    this.onPageChange();
  }

  dateChange(){
    this.tripReportParameters.date = (<HTMLInputElement>document.getElementById('date')).value;
    this.onPageChange();
  }

  departureTimeChange(){
    this.tripReportParameters.departureTime = (<HTMLInputElement>document.getElementById('departureTime')).value;
    this.onPageChange();
  }

  arrivalTimeChange(){
    this.tripReportParameters.arrivalTime = (<HTMLInputElement>document.getElementById('arrivalTime')).value;
    this.onPageChange();
  }
}
