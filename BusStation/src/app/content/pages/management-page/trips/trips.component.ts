import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { TripIncomingDTO } from 'src/app/core/models/incoming/trip-incoming-dto';
import { TripOutgoingDTO } from 'src/app/core/models/outgoing/trip-outgoing-dto';
import { Pagination } from 'src/app/core/models/utility/pagination.interfaces';
import { TripParameters } from 'src/app/core/models/utility/trip-parameters';
import { TripService } from 'src/app/core/services/trip.service';

@Component({
  selector: 'app-trips',
  templateUrl: './trips.component.html',
  styleUrls: ['./trips.component.scss']
})
export class TripsComponent implements OnInit {
  public trips: TripIncomingDTO[] = [];

  public addForm: FormGroup = new FormGroup({});
  public updateForm: FormGroup = new FormGroup({});
  public deleteForm: FormGroup = new FormGroup({});

  public submitted = false;
  public message: string = '';
  public isLoading: boolean = false;

  public metaData: Pagination = {
    totalPages: 0,
    totalCount: 0,
    pageSize: 0,
    hasNext: false,
    hasPrevious: false,
    currentPage: 1
  };

  public params: TripParameters = {
    searchTerm: '',
    pageNumber: 1,
  }

  constructor(
    private tripService: TripService) { }

  ngOnInit(): void {
    this.metaData.currentPage = 1;
    this.sendQuery();
    this.addForm = new FormGroup({
      name: new FormControl('', [Validators.required, Validators.minLength(4)])
    });


    this.updateForm = new FormGroup({
      routeId: new FormControl('', [Validators.required]),
      busStopId: new FormControl('', [Validators.required]),
      minutesInWay: new FormControl('', [Validators.required]),
      waitingTime: new FormControl('', [Validators.required]),
      order: new FormControl()
    });
    this.deleteForm = new FormGroup({
      deleteId: new FormControl()
    });
  }

  public sendQuery(): void {
    this.isLoading = true;
    this.tripService.GetAllTrips(this.params).subscribe(data => {
      this.trips = data;
      this.isLoading = false;
    });
  }

  public onPageChange(page: number = 1): void {
    this.params.pageNumber = page;
    this.sendQuery();
  }

  public search(): void {
    this.params.searchTerm = (<HTMLInputElement>document.getElementById('search')).value;
    this.onPageChange();
  }

  busId: number;
  routeId: number;
  scheduleId: number;
  departureTime: Date;

  public putDataToUpdate(id: number, trip: TripIncomingDTO): void {
    this.updateForm.controls['oldBusId'].setValue(trip.busId);
    this.updateForm.controls['oldRouteId'].setValue(trip.routeId);
    this.updateForm.controls['oldScheduleId'].setValue(trip.scheduleId);
    this.updateForm.controls['oldDepartureTime'].setValue(trip.departureTime);
    this.updateForm.controls['updateId'].setValue(id);
  }

  public putDataToDelete(id: number): void {
    this.updateForm.controls['deleteId'].setValue(id);
  }

  public updateItem(): void {
    if (this.updateForm.invalid) return;

    this.submitted = true;

    const trip: TripOutgoingDTO = {
      routeId: this.updateForm.value.routeId,
      busId: this.updateForm.value.busId,
      scheduleId: this.updateForm.value.scheduleId,
      departureTime: this.updateForm.value.departureTime,
    };

    this.tripService.UpdateTrip(this.updateForm.value.id, trip).subscribe();
  }

  public deleteItem(): void {
    if (this.deleteForm.invalid) return;

    this.submitted = true;
    this.tripService.DeleteTrip(this.deleteForm.value.deleteId).subscribe();
  }

  public addItem(): void {
    if (this.addForm.invalid) return;

    this.submitted = true;

    const trip: TripOutgoingDTO = {
      routeId: this.updateForm.value.routeId,
      busId: this.updateForm.value.busId,
      scheduleId: this.updateForm.value.scheduleId,
      departureTime: this.updateForm.value.departureTime,
    };

    this.tripService.CreateTrip(trip).subscribe();
  }
}
