import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { RouteIncomingDTO } from 'src/app/core/models/incoming/route-incoming-dto';
import { RouteOutgoingDTO } from 'src/app/core/models/outgoing/route-outgoing-dto';
import { RouteService } from 'src/app/core/services/route.service';

@Component({
  selector: 'app-routes',
  templateUrl: './routes.component.html',
  styleUrls: ['./routes.component.scss']
})
export class RoutesComponent implements OnInit {
  public buses: RouteIncomingDTO[] = [];

  public addForm: FormGroup = new FormGroup({});
  public updateForm: FormGroup = new FormGroup({});
  public deleteForm: FormGroup = new FormGroup({});

  public submitted = false;
  public message: string = '';
  public isLoading: boolean = false;

  constructor(
    private routeService: RouteService) { }

  ngOnInit(): void {
    this.sendQuery();
    this.addForm = new FormGroup({
      routeTypeId: new FormControl('', [Validators.required, Validators.minLength(4)])
    });
    this.updateForm = new FormGroup({
      routeTypeId: new FormControl('', [Validators.required, Validators.minLength(4)]),
    });
    this.deleteForm = new FormGroup({
      deleteId: new FormControl()
    });
  }

  public sendQuery(): void {
    this.isLoading = true;
    this.routeService.GetAllRoutes().subscribe(data => {
      this.buses = data;
      console.log(this.buses)
      //this.metaData = JSON.parse(data.headers.get('pagination'));
      this.isLoading = false;
    });
  }

  public onPageChange(page: number = 1): void {
    this.sendQuery();
  }

  public search(): void {
    this.onPageChange();
  }

  public putDataToUpdate(id: number, bus: RouteOutgoingDTO): void {
    this.updateForm.controls['oldRouteTypeId'].setValue(bus.routeTypeId);
    this.updateForm.controls['updateid'].setValue(id);
  }

  public putDataToDelete(id: number): void {
    this.deleteForm.controls['deleteid'].setValue(id);
  }

  public updateItem(): void {
    if (this.updateForm.invalid) return;

    this.submitted = true;

    const bus: RouteOutgoingDTO = {
      routeTypeId: this.addForm.value.routeTypeId
    };

    this.routeService.UpdateRoute(this.updateForm.value.id, bus).subscribe();
  }

  public deleteItem(): void {
    if (this.deleteForm.invalid) return;

    this.submitted = true;
    this.routeService.DeleteRoute(this.deleteForm.value.deleteId).subscribe();
  }

  public addItem(): void {
    if (this.addForm.invalid) return;

    this.submitted = true;

    const bus: RouteOutgoingDTO = {
      routeTypeId: this.addForm.value.routeTypeId
    };

    this.routeService.CreateRoute(bus).subscribe();
  }
}