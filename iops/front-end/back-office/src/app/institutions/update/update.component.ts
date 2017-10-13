import {
  Component, OnInit, trigger, state, style, transition, animate, ChangeDetectionStrategy,
  ChangeDetectorRef
} from '@angular/core';
import {NavbarTitleService} from "../../lbd/services/navbar-title.service";
import {WebService} from "../../core/web.service";
import { Router, ActivatedRoute } from '@angular/router';
import swal from 'sweetalert2';
import 'rxjs/add/operator/switchMap';
import {ConfigService} from "../../core/config.service";

@Component({
  selector: 'app-update',
  templateUrl: './update.component.html',
  styleUrls: ['./update.component.css'],
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
export class UpdateComponent implements OnInit {

  public ContinentName = "";
  public OriginalNewsId = "";
  public Title = "";
  public LastTitle = "";
  public Text = "";
  public PhotoURL = "";

  constructor(
                public config:ConfigService,
                private route: ActivatedRoute,
                public router:Router,
                private change : ChangeDetectorRef,
                private ws:WebService,
                private navbarTitleService: NavbarTitleService) {

    this.route.params.subscribe(params => {
        this.OriginalNewsId=params['id'];
        this.ws.getNews(this.OriginalNewsId)
          .then(data=>{
             if(data.status==1){
                this.Title = data.extra.news.title;
                this.LastTitle = data.extra.news.title;
                this.Text = data.extra.news.text;
                this.PhotoURL = data.extra.news.photoURL;
             }
          });
    });
  }
  ngOnInit() {
  }

  doUpdate(){
    this.ws.updateNews(this.OriginalNewsId,this.Title,this.Text,this.PhotoURL)
      .then(data=>{
        if(data.status===1){
          swal({
            title: 'thank you !',
            type: 'success',
          });
          console.log(data);
          this.router.navigate(['/news/list']);
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

  imageUploaded(e){
    let s  = e.serverResponse;
    if(s.status==200){
      this.PhotoURL =JSON.parse(s._body).extra.filename;
    }
  }

}
