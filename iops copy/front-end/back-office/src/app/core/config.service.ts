import { Injectable } from '@angular/core';

@Injectable()
export class ConfigService {

  constructor() { }

  public SiteName = "IOPS Backoffice";
  public headerLink = "http://localhost:4200/";
  public headerLogoImg = "/assets/img/logo_iops.png";
  public backgroundColor = "#212121";
  public backgroundImg = "/assets/img/parallax-1.jpg";
  public urlServerApi = "http://localhost:5000";
  public CountryID = ""; // "" = IOPS

}
