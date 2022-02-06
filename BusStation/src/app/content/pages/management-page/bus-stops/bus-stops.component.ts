import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { NzNotificationService } from 'ng-zorro-antd/notification';
import { BusStopIncomingDTO } from 'src/app/core/models/incoming/bus-stop-incoming-dto';
import { BusStopOutgoingDTO } from 'src/app/core/models/outgoing/bus-stop-outgoing-dto';
import { BusStopParameters } from 'src/app/core/models/utility/bus-stop-parameters';
import { BusStopService } from 'src/app/core/services/bus-stop.service';

@Component({
  selector: 'app-bus-stops',
  templateUrl: './bus-stops.component.html',
  styleUrls: ['./bus-stops.component.scss']
})
export class BusStopsComponent implements OnInit {
  public busStops: BusStopIncomingDTO[] = [];

  public form: FormGroup = new FormGroup({});

  public submitted = false;
  public message: string = '';
  public isLoading: boolean = true;
  public currentId: number;

  public params: BusStopParameters = {
    searchTerm: '',
    pageNumber: 1,
  }

  constructor(private busStopService: BusStopService,
      private notification: NzNotificationService) { }

  ngOnInit(): void {
    this.form = new FormGroup({
      name: new FormControl('', [Validators.required, Validators.minLength(4)]),
      location: new FormControl('', [Validators.required, Validators.minLength(4)])
    });
    this.sendQuery();
  }

  public sendQuery(): void {
    this.isLoading = true;
    this.busStopService.GetAllBusStops(this.params).subscribe(data => {
      this.busStops = data;
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

  public putDataToUpdate(id: number, busStop: BusStopOutgoingDTO): void {
    this.form.controls['name'].setValue(busStop.name);
    this.form.controls['location'].setValue(busStop.location);
    this.currentId = id;
  }

  public putDataToDelete(id: number): void {
    this.currentId = id;
  }

  public updateItem(): void {
    if (this.form.invalid) return;

    this.submitted = true;

    const busStop: BusStopOutgoingDTO = {
      name: this.form.value.name,
      location: this.form.value.location
    };
    this.busStopService.UpdateBusStop(this.form.value.id, busStop).subscribe();
  }

  public deleteItem(): void {
    this.busStopService.DeleteBusStop(this.currentId).subscribe();
  }

  public addItem(): void {
    if (this.form.invalid) return;

    this.submitted = true;

    const busStop: BusStopOutgoingDTO = {
      name: this.form.value.name,
      location: this.form.value.location
    };

    this.busStopService.CreateBusStop(busStop).subscribe();
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

    const busStop: BusStopOutgoingDTO = {
      name: this.form.value.name,
      location: this.form.value.location,
    };

    this.busStopService.CreateBusStop(busStop).subscribe(res =>{
      this.writeNotification("Result adding!", "New bus stop was added in database.")
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
  showUpdateModal(id: number, busStop: BusStopIncomingDTO): void {
    this.form.controls['name'].setValue(busStop.name);
    this.form.controls['location'].setValue(busStop.location);
    this.currentId = id;
    this.isUpdateVisible = true;
  }

  handleUpdateOk(): void {
    this.isUpdateOkLoading = true;

    if (this.form.invalid) {
      this.isUpdateOkLoading = false;
      return;
    }

    const busStop: BusStopOutgoingDTO = {
      name: this.form.value.name,
      location: this.form.value.location,
    };

    this.busStopService.UpdateBusStop(this.currentId, busStop).subscribe(res =>{
      this.writeNotification("Result updating!", "The bus stop was updated in database.")
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

    this.busStopService.DeleteBusStop(this.currentId).subscribe(res =>{
      this.writeNotification("Result deleting!", "The bus stop was deleted from database.");
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
