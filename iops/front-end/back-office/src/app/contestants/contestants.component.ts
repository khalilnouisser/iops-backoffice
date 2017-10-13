import {
  Component, OnInit, trigger, state, style, transition, animate, ChangeDetectionStrategy,
  ChangeDetectorRef
} from '@angular/core';
import { TableData } from '../lbd/lbd-table/lbd-table.component';
import { NavbarTitleService } from '../lbd/services/navbar-title.service';
import {WebService} from "../core/web.service";
import {DateService} from "../core/date.service";

@Component({
  selector: 'app-users',
  templateUrl: './contestants.component.html',
  styleUrls: ['./contestants.component.css'],
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
export class ContestantsComponent implements OnInit {

  public tableData: TableData = null;

  constructor(private dateService:DateService,private change : ChangeDetectorRef,private ws:WebService,private navbarTitleService: NavbarTitleService) {
  }

  public ngOnInit() {
    this.navbarTitleService.updateTitle('Contestants');
    this.getListContestants();
  }

  getListContestants(){
    this.ws.getListContestants()
      .then(data=>{

        let dataList = [];
        if(data.status===1){
          data.result.forEach(admin=>{

            let c = [];
            c.push(admin.userId);
            c.push(admin.profilePic);
            c.push(admin.firstName);
            c.push(admin.lastName);
            c.push(admin.emailAddress);
            c.push(admin.countryID);
            c.push(admin.regionID);
            c.push(admin.phoneNumber);
            c.push(admin.schoolName);
            c.push(this.dateService.date_diff(new Date(admin.registrationDate)));
            dataList.push(c);
          });

          this.tableData = {
            headerRow: ['ID','image', 'First Name','Last Name','Email','Phone','Country','Region','Institution','Registration Date'],
            dataRows: dataList
          };
        }



      });




/*
    this.ws.getSuperAdmins()
      .then(data=>{
        let dataList = [];
        if(data.status===1){
          data.result.forEach(admin=>{
            let c = [];
            c.push(admin.userId);
            c.push(admin.profilePic);
            c.push(admin.firstName);
            c.push(admin.lastName);
            c.push(admin.emailAddress);
            c.push(admin.internationalContestEdition);
            dataList.push(c);
          });

          this.tableData3 = {
            headerRow: ['ID','', 'First Name','Last Name','Email','Edition'],
            dataRows: dataList
          };
        }
      });*/







  }

}
