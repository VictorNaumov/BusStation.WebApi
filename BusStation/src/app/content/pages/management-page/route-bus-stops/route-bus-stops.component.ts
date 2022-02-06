import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { NzNotificationService } from 'ng-zorro-antd/notification';
import { RouteBusStopIncomingDTO } from 'src/app/core/models/incoming/route-bus-stop-incoming-dto';
import { RouteBusStopOutgoingDTO } from 'src/app/core/models/outgoing/route-bus-stop-outgoing-dto';
import { Pagination } from 'src/app/core/models/utility/pagination.interfaces';
import { RouteBusStopParameters } from 'src/app/core/models/utility/route-bus-stop-parameters';
import { RouteBusStopService } from 'src/app/core/services/route-bus-stop.service';

@Component({
  selector: 'app-route-routeBusStop-stops',
  templateUrl: './route-bus-stops.component.html',
  styleUrls: ['./route-bus-stops.component.scss']
})
export class RouteBusStopsComponent implements OnInit {
  public routeBusStops: RouteBusStopIncomingDTO[] = [];

  public form: FormGroup = new FormGroup({});

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

  public params: RouteBusStopParameters = {
    searchTerm: '',
    pageNumber: 1,
  }

  constructor(
    private routeBusStopService: RouteBusStopService,
    private notification: NzNotificationService) { }

  ngOnInit(): void {
    this.form = new FormGroup({
      routeId: new FormControl('', [Validators.required]),
      busStopId: new FormControl('', [Validators.required]),
      minutesInWay: new FormControl('', [Validators.required]),
      waitingTime: new FormControl('', [Validators.required]),
      order: new FormControl('', [Validators.required]),
    });
    this.sendQuery();
  }

  public sendQuery(): void {
    this.isLoading = true;
    this.routeBusStopService.GetAllRouteBusStops().subscribe(data => {
      this.routeBusStops = data;
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

    const routeBusStop: RouteBusStopOutgoingDTO = {
      routeId: this.form.value.routeId,
      busStopId: this.form.value.busStopId,
      minutesInWay: this.form.value.minutesInWay,
      waitingTime: this.form.value.waitingTime,
      order: this.form.value.order,
    };

    this.routeBusStopService.CreateRouteBusStop(routeBusStop).subscribe(res =>{
      this.writeNotification("Result adding!", "New route was added in database.")
      this.isAddVisible = false;
      this.isAddOkLoading = false;
      this.sendQuery();
    },
    (err: HttpErrorResponse)=>{
      this.writeNotification("Invalid entity!", err.status != 500 ? err.message : "Something went wrong!");
    });
  }

  handleAddCancel(): void {
    this.isAddVisible = false;
  }


  isUpdateVisible = false;
  isUpdateOkLoading = false;
  showUpdateModal(routeBusStop: RouteBusStopIncomingDTO): void {
    this.form.controls['routeId'].setValue(routeBusStop.routeId);
    this.form.controls['busStopId'].setValue(routeBusStop.busStopId);
    this.form.controls['waitingTime'].setValue(routeBusStop.waitingTime);
    this.form.controls['minutesInWay'].setValue(routeBusStop.minutesInWay);
    this.form.controls['order'].setValue(routeBusStop.order);
    this.isUpdateVisible = true;
  }

  handleUpdateOk(): void {
    this.isUpdateOkLoading = true;

    if (this.form.invalid) {
      this.isUpdateOkLoading = false;
      return;
    }

    const routeBusStop: RouteBusStopOutgoingDTO = {
      routeId: this.form.value.routeId,
      busStopId: this.form.value.busStopId,
      minutesInWay: this.form.value.minutesInWay,
      waitingTime: this.form.value.waitingTime,
      order: this.form.value.order,
    };

    this.routeBusStopService.UpdateRouteBusStop(routeBusStop).subscribe(res =>{
      this.writeNotification("Result updating!", "The route was updated in database.")
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
  showDeleteModal(routeBusStop: RouteBusStopIncomingDTO): void {
    this.form.controls['routeId'].setValue(routeBusStop.routeId);
    this.form.controls['busStopId'].setValue(routeBusStop.busStopId);
    this.isDeleteVisible = true;
  }

  handleDeleteOk(): void {
    this.isDeleteOkLoading = true;

    if (this.form.invalid) {
      this.isDeleteOkLoading = false;
      return;
    }


    this.routeBusStopService.DeleteRouteBusStop(this.form.value.routeId, this.form.value.busStopId).subscribe(res =>{
      this.writeNotification("Result deleting!", "The route was deleted from database.");
      this.isDeleteVisible = false;
      this.isDeleteOkLoading = false;
      this.sendQuery();
    },
    (err: HttpErrorResponse) => {
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
