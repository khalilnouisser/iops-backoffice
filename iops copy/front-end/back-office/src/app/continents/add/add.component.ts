import {
  Component, OnInit, trigger, state, style, transition, animate, ChangeDetectionStrategy,
  ChangeDetectorRef
} from '@angular/core';
import {NavbarTitleService} from "../../lbd/services/navbar-title.service";
import {WebService} from "../../core/web.service";
import {Router} from "@angular/router";
import swal from 'sweetalert2';

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

  public ContinentName = "";
  constructor(public router:Router,private change : ChangeDetectorRef,private ws:WebService,private navbarTitleService: NavbarTitleService) {
  }
  ngOnInit() {
  }

  doAdd(){
      this.ws.addContinent(this.ContinentName)
        .then(data=>{
          if(data.status===1){
            swal({
              title: 'thank you !',
              type: 'success',
            });
            this.router.navigate(['/continents/list']);
          }
          else {
            swal({
              title: 'Error!',
              text: data.extra.errorMessage,
              type: 'error',
            });
          }
        });
  }

}
