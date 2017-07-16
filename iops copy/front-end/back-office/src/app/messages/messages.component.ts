import {
  Component, OnInit, trigger, state, style, transition, animate, ChangeDetectionStrategy,
  ChangeDetectorRef
} from '@angular/core';
import { TableData } from '../lbd/lbd-table/lbd-table.component';
import { NavbarTitleService } from '../lbd/services/navbar-title.service';
import {WebService} from "../core/web.service";
import {DateService} from "../core/date.service";

@Component({
  selector: 'app-messages',
  templateUrl: './messages.component.html',
  styleUrls: ['./messages.component.css'],
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
export class MessagesComponent implements OnInit {

  public tableData: TableData = null;

  constructor(private dateService:DateService,private change : ChangeDetectorRef,private ws:WebService,private navbarTitleService: NavbarTitleService) {
    this.getListMessages();
  }

  public ngOnInit() {
    this.navbarTitleService.updateTitle('Messages');
  }

  getListMessages(){
    this.ws.getListMessages()
      .then(data=>{
        let dataList = [];
        if(data.status===1){
          data.extra.messages.forEach(message=>{
            let c = [];
            c.push(message.name);
            c.push(message.emailAddress);
            c.push(message.text);
            c.push(this.dateService.date_diff(new Date(message.dateMessage)));
            dataList.push(c);
          });

          this.tableData = {
            headerRow: ['name', 'emailAddress','message','date'],
            dataRows: dataList
          };

        }
      });
  }

}
