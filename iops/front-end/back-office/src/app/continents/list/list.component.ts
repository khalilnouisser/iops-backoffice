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
    this.getListContinents();
  }
  public tableData: TableData = null;


  public ngOnInit() {
  }

  getListContinents(){
    this.ws.getListContinents()
      .then(data=>{


        let dataList = [];
        if(data.status===1){
          data.extra.continents.forEach(continent=>{
            let c = [];
            c.push(continent.continentID);
            let paysName = "";
            for(let i=0;i<continent.pays.length;i++){
              paysName+=continent.pays[i].name;
              if(i<continent.pays.length-1) paysName+=" , ";
            }
            c.push(paysName);
            dataList.push(c);
          });

          this.tableData = {
            headerRow: ['Continent', 'Countries'],
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
