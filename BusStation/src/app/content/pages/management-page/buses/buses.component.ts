import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { NzNotificationService } from 'ng-zorro-antd/notification';
import { BusIncomingDTO } from 'src/app/core/models/incoming/bus-incoming-dto';
import { BusOutgoingDTO } from 'src/app/core/models/outgoing/bus-outgoing-dto';
import { BusParameters } from 'src/app/core/models/utility/bus-parameters';
import { BusService } from 'src/app/core/services/bus.service';

@Component({
  selector: 'app-buses',
  templateUrl: './buses.component.html',
  styleUrls: ['./buses.component.scss']
})
export class BusesComponent implements OnInit {
  public buses: BusIncomingDTO[] = [];

  public form: FormGroup = new FormGroup({});
  public currentId: number;

  public submitted = false;
  public message: string = '';
  public isLoading: boolean = true;

  public params: BusParameters = {
    searchTerm: '',
    pageNumber: 1,
  }

  constructor(
    private busService: BusService,
    private notification: NzNotificationService) { }

  ngOnInit(): void {
    this.sendQuery();
    this.form = new FormGroup({
      name: new FormControl('', [Validators.required]),
      countOfSeats: new FormControl('', [Validators.required]),
      driver: new FormControl('', [Validators.required]),
      number: new FormControl('', [Validators.required]),
    });
  }

  public sendQuery(): void {
    this.isLoading = true;
    this.busService.GetAllBuses(this.params).subscribe(data => {
      this.buses = data;
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

    const bus: BusOutgoingDTO = {
      name: this.form.value.name,
      driver: this.form.value.driver,
      number: this.form.value.number,
      countOfSeats: this.form.value.countOfSeats
    };

    this.busService.CreateBus(bus).subscribe(res =>{
      this.writeNotification("Result adding!", "New bus was added in database.")
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
  showUpdateModal(id: number, bus: BusIncomingDTO): void {
    this.form.controls['name'].setValue(bus.name);
    this.form.controls['number'].setValue(bus.number);
    this.form.controls['driver'].setValue(bus.driver);
    this.form.controls['countOfSeats'].setValue(bus.countOfSeats);
    this.currentId = id;
    this.isUpdateVisible = true;
  }

  handleUpdateOk(): void {
    this.isUpdateOkLoading = true;

    if (this.form.invalid) {
      this.isUpdateOkLoading = false;
      return;
    }

    const bus: BusOutgoingDTO = {
      name: this.form.value.name,
      driver: this.form.value.driver,
      number: this.form.value.number,
      countOfSeats: this.form.value.countOfSeats
    };

    this.busService.UpdateBus(this.currentId, bus).subscribe(res =>{
      this.writeNotification("Result updating!", "The bus was updated in database.")
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

    this.busService.DeleteBus(this.currentId).subscribe(res =>{
      this.writeNotification("Result deleting!", "The bus was deleted from database.");
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
