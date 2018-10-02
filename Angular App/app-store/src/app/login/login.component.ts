import { Component, OnInit } from '@angular/core';
import { LoginService } from './services/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  providers: [LoginService]
})
export class LoginComponent implements OnInit {

  constructor(private service: LoginService) {
    debugger
    this.service.CS();
  }

  ngOnInit() {

  }

}
