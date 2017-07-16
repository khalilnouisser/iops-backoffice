import { Component, OnInit } from '@angular/core';
import swal from 'sweetalert2';
import {AuthService} from "../core/auth.service";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  emailAdresse = '';
  password= '';

  constructor(private authService : AuthService) { }

  ngOnInit() {
  }

  doLogin(){
    console.log("clicked");
    if( (this.emailAdresse.length*this.password.length) === 0) {
      swal({
        title: 'Error!',
        text: 'Please check your information.',
        type: 'error',
      });
    }
    else {
      console.log("here");
      this.authService.signIn(this.emailAdresse,this.password)
        .then(data=>{
          if(data.status===1){
            swal({
              title: 'Welcome!',
              text: data.extra.admin.fname+" "+data.extra.admin.lname,
              type: 'success',
            });
            this.authService.saveAdminConnected(data.extra.admin);
          }
          else {
            swal({
              title: 'Error!',
              text: 'Please check your information.',
              type: 'error',
            });
            this.password="";
          }
        });

    }
  }

}
