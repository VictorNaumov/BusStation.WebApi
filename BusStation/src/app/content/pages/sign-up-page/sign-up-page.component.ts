import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { AuthService } from 'src/app/core/account/auth-service';
import { AdminRegistrationDTO } from 'src/app/core/models/admin/admin-registration-dto';
import { AdminRegistrationParameters } from 'src/app/core/models/utility/admin-registration-parameters';
import { NotificationService } from 'src/app/core/services/notification-service';

@Component({
  selector: 'app-sign-up-page',
  templateUrl: './sign-up-page.component.html',
  styleUrls: ['./sign-up-page.component.scss']
})
export class SignUpPageComponent implements OnInit {
  public form: FormGroup = new FormGroup({});
  public submitted: boolean = false;
  public message: string = '';

  parameters: AdminRegistrationParameters = {
    secretKey: "",
  };

  constructor(public authService: AuthService,
    private router: Router,
    private route: ActivatedRoute,
    private notificationService: NotificationService) { }



  ngOnInit(): void {
    this.route.queryParams.subscribe((params: Params) => {
      if (params.loginAgain)
        this.message = 'Please, enter data';
      else if (params.authFailed)
        this.message = 'Session ended. Enter data again.';
    });

    this.form = new FormGroup({
      login: new FormControl('', [Validators.required, Validators.minLength(4)]),
      email: new FormControl('', [Validators.required, Validators.email]),
      confirmpassword: new FormControl('', [Validators.required, Validators.minLength(4)]),
      password: new FormControl('', [Validators.required, Validators.minLength(6)]),
      secretKey: new FormControl('', [Validators.required, Validators.minLength(6)])
    });
  }

  public submit(): void {
    if (this.form.invalid || this.form.value.password != this.form.value.confirmpassword){
      return;
    }
    this.notificationService.ErrorNotice("suck")

    this.submitted = true;

    const user: AdminRegistrationDTO = {
      userName: this.form.value.login,
      password: this.form.value.password,
      email: this.form.value.email,
    };

    this.parameters.secretKey = this.form.value.secretKey;

    this.authService.signup(user, this.parameters).subscribe(() => {
      this.form.reset();
      this.router.navigate(['/']);
      this.submitted = false;
    }, () => {
      this.submitted = false;
    });
  }
}
