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
  public isLoading: boolean = true;

  public params: BusParameters = {
    searchTerm: '',
    pageNumber: 1,
  }

  constructor(
    private busService: BusService) { }

  ngOnInit(): void {
    this.sendQuery();
    this.addForm = new FormGroup({
      name: new FormControl('', [Validators.required]),
      countOfSeats: new FormControl('', [Validators.required]),
      driver: new FormControl('', [Validators.required]),
      number: new FormControl('', [Validators.required]),
    });
    this.updateForm = new FormGroup({
      oldName: new FormControl('', [Validators.required]),
      oldCountOfSeats: new FormControl('', [Validators.required]),
      oldDriver: new FormControl('', [Validators.required]),
      oldNumber: new FormControl('', [Validators.required]),
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
    this.updateForm.controls['oldName'].setValue(bus.name);
    this.updateForm.controls['oldNumber'].setValue(bus.name);
    this.updateForm.controls['oldDriver'].setValue(bus.name);
    this.updateForm.controls['oldCountOfSeats'].setValue(bus.name);
    this.updateForm.controls['updateId'].setValue(id);
  }

  public putDataToDelete(id: number): void {
    this.deleteForm.controls['deleteId'].setValue(id);
  }

  public updateItem(): void {
    if (this.updateForm.invalid) return;

    this.submitted = true;

    const bus: BusOutgoingDTO = {
      name: this.updateForm.value.oldName,
      number: this.updateForm.value.oldNumber,
      driver: this.updateForm.value.oldDriver,
      countOfSeats: this.updateForm.value.oldCountOfSeats,
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
