import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
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

  public params: RouteBusStopParameters = {
    searchTerm: '',
    pageNumber: 1,
  }

  constructor(
    private routeBusStopService: RouteBusStopService) { }

  ngOnInit(): void {
    this.metaData.currentPage = 1;
    this.addForm = new FormGroup({
      routeId: new FormControl('', [Validators.required]),
      busStopId: new FormControl('', [Validators.required]),
      minutesInWay: new FormControl('', [Validators.required]),
      waitingTime: new FormControl('', [Validators.required]),
      order: new FormControl('', [Validators.required]),
    });


    this.updateForm = new FormGroup({
      oldRouteId: new FormControl('', [Validators.required]),
      oldBusStopId: new FormControl('', [Validators.required]),
      oldMinutesInWay: new FormControl('', [Validators.required]),
      oldWaitingTime: new FormControl('', [Validators.required]),
      oldOrder: new FormControl('', [Validators.required]),
    });
    this.deleteForm = new FormGroup({
      routeId: new FormControl('', [Validators.required]),
      busStopId: new FormControl('', [Validators.required]),
      order: new FormControl()
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

  public putDataToUpdate(routeBusStop: RouteBusStopOutgoingDTO): void {
    this.updateForm.controls['oldRouteId'].setValue(routeBusStop.routeId);
    this.updateForm.controls['oldBusStopId'].setValue(routeBusStop.busStopId);
    this.updateForm.controls['oldWaitingTime'].setValue(routeBusStop.minutesInWay);
    this.updateForm.controls['oldOrder'].setValue(routeBusStop.order);
  }

  public putDataToDelete(routeBusStop: RouteBusStopOutgoingDTO): void {
    this.deleteForm.controls['routeId'].setValue(routeBusStop.routeId);
    this.updateForm.controls['busStopId'].setValue(routeBusStop.busStopId);
  }

  public updateItem(): void {
    if (this.updateForm.invalid) return;

    this.submitted = true;

    const routeBusStop: RouteBusStopOutgoingDTO = {
      routeId: this.updateForm.value.routeId,
      busStopId: this.updateForm.value.busStopId,
      minutesInWay: this.updateForm.value.minutesInWay,
      waitingTime: this.updateForm.value.waitingTime,
      order: this.updateForm.value.order,
    };

    this.routeBusStopService.UpdateRouteBusStop(this.updateForm.value.id, routeBusStop).subscribe();
  }

  public deleteItem(): void {
    if (this.deleteForm.invalid) return;

    this.submitted = true;
    this.routeBusStopService.DeleteRouteBusStop(this.deleteForm.value.deleteId).subscribe();
  }

  public addItem(): void {
    if (this.addForm.invalid) return;

    this.submitted = true;

    const routeBusStop: RouteBusStopOutgoingDTO = {
      routeId: this.updateForm.value.routeId,
      busStopId: this.updateForm.value.busStopId,
      minutesInWay: this.updateForm.value.minutesInWay,
      waitingTime: this.updateForm.value.waitingTime,
      order: this.updateForm.value.order,
    };

    this.routeBusStopService.CreateRouteBusStop(routeBusStop).subscribe();
  }
}
