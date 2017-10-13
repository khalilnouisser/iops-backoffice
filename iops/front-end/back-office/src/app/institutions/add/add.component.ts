import {
  Component, OnInit, trigger, state, style, transition, animate, ChangeDetectionStrategy,
  ChangeDetectorRef
} from '@angular/core';
import {NavbarTitleService} from "../../lbd/services/navbar-title.service";
import {WebService} from "../../core/web.service";
import {Router} from "@angular/router";
import swal from 'sweetalert2';
import {ConfigService} from "../../core/config.service";
import { Http, Headers,Response } from '@angular/http';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.css'],
  animations: [
    trigger('cardtable1', [
      state('*', style({
        '-ms-transform': 'translate3D(0px, 0px, 0px)',
        '-webkit-transform': 'translate3D(0px, 0px, 0px)',
        '-moz-transform': 'translate3D(0px, 0px, 0px)',
        '-o-transform': 'translate3D(0px, 0px, 0px)',
        transform: 'translate3D(0px, 0px, 0px)',
        opacity: 1})),
      transition('void => *', [
        style({opacity: 0,
          '-ms-transform': 'translate3D(0px, 150px, 0px)',
          '-webkit-transform': 'translate3D(0px, 150px, 0px)',
          '-moz-transform': 'translate3D(0px, 150px, 0px)',
          '-o-transform': 'translate3D(0px, 150px, 0px)',
          transform: 'translate3D(0px, 150px, 0px)',
        }),
        animate('0.3s 0s ease-out')
      ])
    ])
  ]
})
export class AddComponent implements OnInit {

  public name = "";
  public zipCode = 0;
  public adress = "";
  public regionID = "";
  public countryName = "";
  public discriminator = "University";
  public listCountries = [];
  public listRegions = [];
  public listCountriesOb = [];
  constructor(public config:ConfigService,public router:Router,private change : ChangeDetectorRef,private ws:WebService,private navbarTitleService: NavbarTitleService) {
    this.getListCountries();
  }
  ngOnInit() {
  }

  getListCountries(){
    this.ws.getListCountries()
      .then(data=>{
        if(data.status===1){
          this.listCountriesOb = data.list;
          data.list.forEach(country=>{
            this.listCountries.push(country.countryName);
          });

          console.log(this.listCountries);

        }
      });
  }

  updateListRegions(){
    console.log(this.listCountriesOb);
    this.listRegions = [];
    this.regionID = "";
    if(this.countryName != "")
    this.listCountriesOb.find(k=>k.countryName == this.countryName).regions.forEach(k=>{
      this.listRegions.push(k.regionID);
    });
  }

  doAdd(){
      this.ws.addInstitution(this.name,this.zipCode,this.adress,this.regionID,this.discriminator)
        .then(data=>{
          if(data.status===1){
            swal({
              title: 'thank you !',
              type: 'success',
            });
            this.router.navigate(['/institutions/list']);
          }
          else {
            swal({
              title: 'Error!',
              text: data.message,
              type: 'error',
            });
          }
        });
  }
}
