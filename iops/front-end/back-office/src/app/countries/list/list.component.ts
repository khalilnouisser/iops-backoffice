
import {
  Component, OnInit, trigger, state, style, transition, animate, ChangeDetectionStrategy,
  ChangeDetectorRef
} from '@angular/core';
import {WebService} from "../../core/web.service";
import {NavbarTitleService} from "../../lbd/services/navbar-title.service";
import {TableData} from "../../lbd/lbd-table/lbd-table.component";
import {Router} from "@angular/router";
import swal from 'sweetalert2';
import {ConfigService} from "../../core/config.service";

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css'],
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
export class ListComponent implements OnInit {

  constructor(private config: ConfigService,public router:Router,private change : ChangeDetectorRef,private ws:WebService,private navbarTitleService: NavbarTitleService) {
  }
  public tableData: TableData = null;


  public ngOnInit() {
    this.getListContinents();
  }

  getListContinents(){
    this.ws.getListCountries()
      .then(data=>{


        let dataList = [];
        if(data.status===1){
          data.list.forEach(country=>{
            let c = [];
            c.push(country.flag);
            c.push(country.countryName);
            c.push(country.webSite);
            c.push(country.continentID);
            let paysName = "";
            for(let i=0;i<country.regions.length;i++){
              paysName+=country.regions[i].regionID;
              if(i<country.regions.length-1) paysName+=" , ";
            }

            c.push(paysName);

            console.log(c);
            dataList.push(c);
          });

          this.tableData = {
            headerRow: ['', 'Name' , 'web site' , 'continent' , 'Regions'],
            dataRows: dataList
          };

        }
      });
  }

  onDelete(index){
    console.log(index);
    let self = this;
    swal({
      title: 'Are you sure?',
      text: "You won't be able to revert this!",
      type: 'warning',
      showCancelButton: true,
      confirmButtonColor: this.config.backgroundColor,
      cancelButtonColor: '#d33',
      confirmButtonText: 'Yes, delete it!'
    }).then(function () {
      self.ws.removeContient(self.tableData.dataRows[index][0]);
      self.tableData.dataRows.splice(index,1);
      swal(
        'Deleted!',
        'Your Continent has been deleted.',
        'success'
      );
    });
  }

}
