import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { NzNotificationService } from 'ng-zorro-antd/notification';
import { RouteIncomingDTO } from 'src/app/core/models/incoming/route-incoming-dto';
import { RouteOutgoingDTO } from 'src/app/core/models/outgoing/route-outgoing-dto';
import { RouteService } from 'src/app/core/services/route.service';

@Component({
  selector: 'app-routes',
  templateUrl: './routes.component.html',
  styleUrls: ['./routes.component.scss']
})
export class RoutesComponent implements OnInit {
  public routes: RouteIncomingDTO[] = [];

  public form: FormGroup = new FormGroup({});
  public currentId: number;

  public submitted = false;
  public message: string = '';
  public isLoading: boolean = true;

  constructor(private routeService: RouteService,
              private notification: NzNotificationService) { }

  ngOnInit(): void {
    this.form = new FormGroup({
      routeTypeId: new FormControl('', [Validators.required])
    });
    this.sendQuery();
  }

  public sendQuery(): void {
    this.isLoading = true;
    this.routeService.GetAllRoutes().subscribe(data => {
      this.routes = data;
      this.isLoading = false;
    });
  }

  public onPageChange(page: number = 1): void {
    this.sendQuery();
  }

  public search(): void {
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

    const route: RouteOutgoingDTO = {
      routeTypeId: this.form.value.routeTypeId
    };

    this.routeService.CreateRoute(route).subscribe(res =>{
      this.writeNotification("Result adding!", "New route was added in database.")
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
  showUpdateModal(id: number, route: RouteIncomingDTO): void {
    this.form.controls['routeTypeId'].setValue(route.routeTypeId);
    this.currentId = id;
    this.isUpdateVisible = true;
  }

  handleUpdateOk(): void {
    this.isUpdateOkLoading = true;

    if (this.form.invalid) {
      this.isUpdateOkLoading = false;
      return;
    }

    const route: RouteOutgoingDTO = {
      routeTypeId: this.form.value.routeTypeId
    };

    this.routeService.UpdateRoute(this.currentId, route).subscribe(res =>{
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

    this.routeService.DeleteRoute(this.currentId).subscribe(res =>{
      this.writeNotification("Result deleting!", "The route was deleted from database.");
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
