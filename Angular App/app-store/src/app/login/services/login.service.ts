import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

interface LoginResponse {
  token?: string;
  errorMessage?: string;
  success: boolean;
}

@Injectable()
export class LoginService {

  private _url = environment.endPoint;

  constructor(private http: HttpClient) {

  }

  login(params: {
    username: any;
    password: any;
  }): Observable<LoginResponse> {
    return this.http.post<LoginResponse>(this._url + 'user/login', params);
  }

}
