import { Injectable } from '@angular/core';
import { Http, Headers,Response } from '@angular/http';
import 'rxjs/';
import {Admin} from "../shared/Admin";
import {ConfigService} from "./config.service";
import {Observable} from "rxjs/Observable";
import {Title} from "@angular/platform-browser";

@Injectable()
export class WebService {

  private headers = new Headers({
    'Content-Type': 'application/json'
  });

  constructor(private config: ConfigService, private http: Http) {
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

  /*
    Contients
   */
  getListContinents() : Promise<any>{
    return this.http.get(this.config.urlServerApi+"/api/Continent",{headers:this.headers})
      .toPromise()
      .then(this.extractData)
      .catch(this.handleError);
  }

  getListContestants() : Promise<any>{
    return this.http.get(this.config.urlServerApi+"/api/Contestant",{headers:this.headers})
      .toPromise()
      .then(this.extractData)
      .catch(this.handleError);
  }



  getListCountries() : Promise<any>{
    return this.http.get(this.config.urlServerApi+"/api/Country",{headers:this.headers})
      .toPromise()
      .then(this.extractData)
      .catch(this.handleError);
  }

  addContinent(ContinentName) : Promise<any>{
    let body = {
      continentName:ContinentName
    };
    return this.http.post(this.config.urlServerApi+"/api/Continent",JSON.stringify(body),{headers:this.headers})
      .toPromise()
      .then(this.extractData)
      .catch(this.handleError);
  }

  updateContinent(ContinentName,LastContinentName) : Promise<any>{
    let body = {
      continentName:ContinentName
    };
    return this.http.put(this.config.urlServerApi+"/api/Continent/"+LastContinentName,JSON.stringify(body),{headers:this.headers})
      .toPromise()
      .then(this.extractData)
      .catch(this.handleError);
  }

  removeContient(ContinentName){
     this.http.delete(this.config.urlServerApi+"/api/Continent/"+ContinentName,{headers:this.headers})
       .toPromise();
    }

    /*
      Messages
     */

  getListMessages(){
    return this.http.get(this.config.urlServerApi+"/api/contactUS/"+this.config.CountryID,{headers:this.headers})
      .toPromise()
      .then(this.extractData)
      .catch(this.handleError);
  }

  getSuperAdmins(){
    return this.http.get(this.config.urlServerApi+"/api/Admin/super/"+this.config.CountryID,{headers:this.headers})
      .toPromise()
      .then(this.extractData)
      .catch(this.handleError);
  }


  getCountryAdmins(){
    return this.http.get(this.config.urlServerApi+"/api/Admin/country/"+this.config.CountryID,{headers:this.headers})
      .toPromise()
      .then(this.extractData)
      .catch(this.handleError);
  }

  getLocalAdmins(){
    return this.http.get(this.config.urlServerApi+"/api/Admin/local/"+this.config.CountryID,{headers:this.headers})
      .toPromise()
      .then(this.extractData)
      .catch(this.handleError);
  }

  /*
    News
   */

  getListNews(){
    return this.http.get(this.config.urlServerApi+"/api/news/all",{headers:this.headers})
      .toPromise()
      .then(this.extractData)
      .catch(this.handleError);
  }

  getListInstitutions(){
    return this.http.get(this.config.urlServerApi+"/api/Institutions",{headers:this.headers})
      .toPromise()
      .then(this.extractData)
      .catch(this.handleError);
  }

  addNews(Title,Text,PhotoURL){
    let body = {
      Title:Title,
      Text:Text,
      PhotoURL:PhotoURL
    };
    return this.http.post(this.config.urlServerApi+"/api/News/",JSON.stringify(body),{headers:this.headers})
      .toPromise()
      .then(this.extractData)
      .catch(this.handleError);
  }

  addInstitution(name,zipCode,adress,regionID,discriminator){
    let body = {
      name:name,
      zipCode:zipCode,
      adress:adress,
      regionID:regionID,
    };
    return this.http.post(this.config.urlServerApi+"/api/Institutions/"+discriminator,JSON.stringify(body),{headers:this.headers})
      .toPromise()
      .then(this.extractData)
      .catch(this.handleError);
  }

  removeNews(NewsId){
    this.http.delete(this.config.urlServerApi+"/api/news/"+NewsId,{headers:this.headers})
      .toPromise();
  }

  removeInstitution(name){
    this.http.delete(this.config.urlServerApi+"/api/Institutions/"+name,{headers:this.headers})
      .toPromise();
  }

  getNews(id){
    return this.http.get(this.config.urlServerApi+"/api/news/"+id,{headers:this.headers})
      .toPromise()
      .then(this.extractData)
      .catch(this.handleError);
  }

  updateNews(id,newTitle,newText,newPhotoURL){
    let body = {
      Title:newTitle,
      Text:newText,
      PhotoURL:newPhotoURL
    };
    return this.http.put(this.config.urlServerApi+"/api/news/"+id,JSON.stringify(body),{headers:this.headers})
      .toPromise()
      .then(this.extractData)
      .catch(this.handleError);
  }

}

