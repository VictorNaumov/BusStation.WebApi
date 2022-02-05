import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { BusIncomingDTO } from 'src/app/core/models/incoming/bus-incoming-dto';
import { BusOutgoingDTO } from 'src/app/core/models/outgoing/bus-outgoing-dto';
import { BusParameters } from 'src/app/core/models/utility/bus-parameters';
import { Pagination } from 'src/app/core/models/utility/pagination.interfaces';
import { BusService } from 'src/app/core/services/bus.service';

@Component({
  selector: 'app-buses',
  templateUrl: './buses.component.html',
  styleUrls: ['./buses.component.scss']
})
export class BusesComponent implements OnInit {
  public buses: BusIncomingDTO[] = [];

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

  public params: BusParameters = {
    searchTerm: '',
    pageNumber: 1,
  }

  constructor(
    private busService: BusService) { }

  ngOnInit(): void {
    this.metaData.currentPage = 1;
    this.sendQuery();
    this.addForm = new FormGroup({
      name: new FormControl('', [Validators.required, Validators.minLength(4)])
    });
    this.updateForm = new FormGroup({
      name: new FormControl('', [Validators.required, Validators.minLength(4)]),
      countOfSeats: new FormControl('', [Validators.required, Validators.minLength(4)]),
      driver: new FormControl('', [Validators.required, Validators.minLength(4)]),
      number: new FormControl('', [Validators.required, Validators.minLength(4)]),
      updateId: new FormControl()
    });
    this.deleteForm = new FormGroup({
      deleteId: new FormControl()
    });
  }

  public sendQuery(): void {
    this.isLoading = true;
    this.busService.GetAllBuses(this.params).subscribe(data => {
      this.buses = data;
      console.log(this.buses)
      //this.metaData = JSON.parse(data.headers.get('pagination'));
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

  public putDataToUpdate(id: number, bus: BusOutgoingDTO): void {
    this.updateForm.controls['oldname'].setValue(bus.name);
    this.updateForm.controls['updateid'].setValue(id);
  }

  public putDataToDelete(id: number): void {
    this.deleteForm.controls['deleteid'].setValue(id);
  }

  public updateItem(): void {
    if (this.updateForm.invalid) return;

    this.submitted = true;

    const bus: BusOutgoingDTO = {
      name: this.updateForm.value.name,
      number: this.updateForm.value.number,
      driver: this.updateForm.value.driver,
      countOfSeats: this.updateForm.value.countOfSeats,
    };
    this.busService.UpdateBus(this.updateForm.value.id, bus).subscribe();
  }

  public deleteItem(): void {
    if (this.deleteForm.invalid) return;

    this.submitted = true;
    this.busService.DeleteBus(this.deleteForm.value.deleteId).subscribe();
  }

  public addItem(): void {
    if (this.addForm.invalid) return;

    this.submitted = true;

    const bus: BusOutgoingDTO = {
      name: this.addForm.value.name,
      driver: this.addForm.value.driver,
      number: this.addForm.value.number,
      countOfSeats: this.addForm.value.countOfSeats
    };

    this.busService.CreateBus(bus).subscribe();
  }
}
