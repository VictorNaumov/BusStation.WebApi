import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { BusStopIncomingDTO } from 'src/app/core/models/incoming/bus-stop-incoming-dto';
import { BusStopOutgoingDTO } from 'src/app/core/models/outgoing/bus-stop-outgoing-dto';
import { BusStopParameters } from 'src/app/core/models/utility/bus-stop-parameters';
import { Pagination } from 'src/app/core/models/utility/pagination.interfaces';
import { BusStopService } from 'src/app/core/services/bus-stop.service';

@Component({
  selector: 'app-bus-stops',
  templateUrl: './bus-stops.component.html',
  styleUrls: ['./bus-stops.component.scss']
})
export class BusStopsComponent implements OnInit {
  public busStops: BusStopIncomingDTO[] = [];

  public addForm: FormGroup = new FormGroup({});
  public updateForm: FormGroup = new FormGroup({});
  public deleteForm: FormGroup = new FormGroup({});

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

  public params: BusStopParameters = {
    searchTerm: '',
    pageNumber: 1,
  }

  constructor(private busStopService: BusStopService) { }

  ngOnInit(): void {
    this.metaData.currentPage = 1;
    this.addForm = new FormGroup({
      name: new FormControl('', [Validators.required, Validators.minLength(4)])
    });
    this.updateForm = new FormGroup({
      name: new FormControl('', [Validators.required, Validators.minLength(4)]),
      location: new FormControl('', [Validators.required, Validators.minLength(4)]),
      updateId: new FormControl()
    });
    this.deleteForm = new FormGroup({
      deleteId: new FormControl()
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
    this.updateForm.controls['oldName'].setValue(busStop.name);
    this.updateForm.controls['oldLocation'].setValue(busStop.location);
    this.updateForm.controls['updateId'].setValue(id);
  }

  public putDataToDelete(id: number): void {
    this.deleteForm.controls['deleteId'].setValue(id);
  }

  public updateItem(): void {
    if (this.updateForm.invalid) return;

    this.submitted = true;

    const busStop: BusStopOutgoingDTO = {
      name: this.addForm.value.name,
      location: this.addForm.value.location
    };
    this.busStopService.UpdateBusStop(this.updateForm.value.id, busStop).subscribe();
  }

  public deleteItem(): void {
    if (this.deleteForm.invalid) return;

    this.submitted = true;
    this.busStopService.DeleteBusStop(this.deleteForm.value.deleteId).subscribe();
  }

  public addItem(): void {
    if (this.addForm.invalid) return;

    this.submitted = true;

    const busStop: BusStopOutgoingDTO = {
      name: this.addForm.value.name,
      location: this.addForm.value.location
    };

    this.busStopService.CreateBusStop(busStop).subscribe();
  }
}
