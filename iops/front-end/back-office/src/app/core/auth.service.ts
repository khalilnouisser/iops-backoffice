import { Injectable } from '@angular/core';
import { Http, Headers,Response } from '@angular/http';
import 'rxjs/';
import {Admin} from "../shared/Admin";

@Injectable()
export class AuthService {
  private urlServerApi = "http://localhost:5000";
  private headers = new Headers({
  'Content-Type': 'application/json'});
  constructor(private http:Http) { }
  public userConncted(): boolean {
    return this.getCurrentAdminConnected()!=null;
  }
  public saveAdminConnected(admin:Admin){
      localStorage.setItem("connectedAdmin",JSON.stringify(admin));
  }

  public getCurrentAdminConnected():Admin{
      return JSON.parse(localStorage.getItem("connectedAdmin"));
  }
  public extractData(res:Response) {
    let body = res.json();
    return body;
  }
  private handleError(error:Response | any) {
    // In a real world app, we might use a remote logging infrastructure
    let errMsg:string;
    if (error instanceof Response) {
      const body = error.json() || '';
      const err = body.error || JSON.stringify(body);
      errMsg = `${error.status} - ${error.statusText || ''} ${err}`;
    } else {
      errMsg = error.message ? error.message : error.toString();
    }
    console.error(errMsg);
    return Promise.reject(errMsg);
  }
  signIn(emailAdress , AdminPassword) {
    let body = {
      "EmailAdress":emailAdress,
      "AdminPassword":AdminPassword
    };

    return this.http.post(this.urlServerApi+"/api/Admin/signin",JSON.stringify(body),{headers:this.headers})
      .toPromise()
      .then(this.extractData)
      .catch(this.handleError);
  }

}
