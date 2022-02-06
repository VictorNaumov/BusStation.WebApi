import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { NzNotificationService } from 'ng-zorro-antd/notification';
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

  public form: FormGroup = new FormGroup({});
  public currentId: number;

  public submitted = false;
  public message: string = '';
  public isLoading: boolean = true;

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
    private tripService: TripService,
    private notification: NzNotificationService) { }

  ngOnInit(): void {
    this.form = new FormGroup({
     busId: new FormControl('', [Validators.required]),
     routeId: new FormControl('', [Validators.required]),
     scheduleId: new FormControl('', [Validators.required]),
     departureTime: new FormControl('', [Validators.required]),
    });

    this.sendQuery();
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

  isAddVisible = false;
  isAddOkLoading = false;
  showAddModal(): void {
    this.isAddVisible = true;
  }

  handleAddOk(): void {
    this.isAddOkLoading = true;

    if (this.form.invalid) {
      this.isAddOkLoading = false;
      return;
    }

    const trip: TripOutgoingDTO = {
      routeId: this.form.value.routeId,
      busId: this.form.value.busId,
      scheduleId: this.form.value.scheduleId,
      departureTime: this.form.value.departureTime,
    };

    this.tripService.CreateTrip(trip).subscribe(res =>{
      this.writeNotification("Result adding!", "New trip was added in database.")
      this.isAddVisible = false;
      this.isAddOkLoading = false;
      this.sendQuery();
    },
    (err: HttpErrorResponse)=>{
      console.log(err);
      this.writeNotification("Invalid entity!", err.status != 500 ? err.message : "Something went wrong!");
    });
  }

  handleAddCancel(): void {
    this.isAddVisible = false;
  }


  isUpdateVisible = false;
  isUpdateOkLoading = false;
  showUpdateModal(id: number, trip: TripIncomingDTO): void {
    this.form.controls['routeId'].setValue(trip.routeId);
    this.form.controls['busId'].setValue(trip.busId);
    this.form.controls['scheduleId'].setValue(trip.scheduleId);
    this.form.controls['departureTime'].setValue(trip.departureTime);
    this.currentId = id;
    this.isUpdateVisible = true;
  }

  handleUpdateOk(): void {
    this.isUpdateOkLoading = true;

    if (this.form.invalid) {
      this.isUpdateOkLoading = false;
      return;
    }

    const trip: TripOutgoingDTO = {
      routeId: this.form.value.oldRouteId,
      busId: this.form.value.oldBusId,
      scheduleId: this.form.value.oldScheduleId,
      departureTime: this.form.value.oldDepartureTime,
    };

    this.tripService.UpdateTrip(this.currentId, trip).subscribe(res =>{
      this.writeNotification("Result updating!", "The trip was updated in database.")
      this.isUpdateVisible = false;
      this.isUpdateOkLoading = false;
      this.sendQuery();
    },
    (err: HttpErrorResponse)=>{
      this.writeNotification("Invalid entity!", err.status != 500 ? err.message : "Something went wrong!");
     });
    }

  handleUpdateCancel(): void {
    this.isUpdateVisible = false;
  }

  isDeleteVisible = false;
  isDeleteOkLoading = false;
  showDeleteModal(id: number): void {
    this.currentId = id;
    this.isDeleteVisible = true;
  }

  handleDeleteOk(): void {
    this.isDeleteOkLoading = true;

    if (this.form.invalid) {
      this.isDeleteOkLoading = false;
      return;
    }

    this.tripService.DeleteTrip(this.currentId).subscribe(res =>{
      this.writeNotification("Result deleting!", "The trip was deleted from database.");
      this.isDeleteVisible = false;
      this.isDeleteOkLoading = false;
      this.sendQuery();
    },
    (err: HttpErrorResponse)=>{
      this.writeNotification("Invalid entity!", err.status != 500 ? err.message : "Something went wrong!");
    });
  }

  handleDeleteCancel(): void {
    this.isDeleteVisible = false;
  }

  writeNotification(header: string, text:string){
    this.notification.blank(
      header,
      text,
      { nzDuration: 10000 }
    );
  }
}
