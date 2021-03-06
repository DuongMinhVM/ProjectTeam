import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { Subject } from 'rxjs';
import swal from 'sweetalert2';
import { takeUntil, filter, map } from 'rxjs/operators';
import { UserService } from '../../../shared/services/user.service';
import { environment } from '../../../../environments/environment';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: [ './login.component.css' ],
  providers: []
})
export class LoginComponent implements OnInit, OnDestroy {

  formLogin: FormGroup;
  destroy$ = new Subject();
  constructor(private service: UserService, private formBuilder: FormBuilder) {
  }

  ngOnInit() {
    this.initialLoginForm();
  }

  ngOnDestroy() {
    this.destroy$.next();
  }

  initialLoginForm() {
    this.formLogin = this.formBuilder.group({
      username: [''],
      password: ['']
    },
    {
      validator: [
        this.validUsernameAndPassword
      ]
    });
  }

  validUsernameAndPassword(form: FormGroup) {
    const username = form.get('username');
    const password = form.get('password');
    if (!username.value) {
      username.setErrors({
        error: 'Username is required.'
      });
    } else if ((username.value as string).length < 8) {
      username.setErrors({
        error: 'Username must be at least 8 characters long.'
      });
    }
    if (!password.value) {
      password.setErrors({
        error: 'Password is required.'
      });
    } else if ((password.value as string).length < 8) {
      password.setErrors({
        error: 'Password must be at least 8 characters long.'
      });
    }
  }

  submitLogin() {
    const isValidForm = this.formLogin.valid;
    if (isValidForm) {
      const params = this.formLogin.value;
      this.service.login(params).pipe(
        takeUntil(this.destroy$),
        filter(rs => !!rs),
        map(
          data => {
            if (!data.success) {
              this._alertError(data.errorMessage);
            } else {
              const key = btoa(environment.keyToken);
              const value = data.token;
              localStorage.setItem(key, value);
            }
          }
        )
        ).subscribe();
    } else {
      this._alertError('CLIENT ERROR!');
    }
  }

  private _alertSuccess(message: string) {
    swal('Success', message, 'success');
  }

  private _alertError(message: string) {
    swal('Error', message, 'error');
  }

}
