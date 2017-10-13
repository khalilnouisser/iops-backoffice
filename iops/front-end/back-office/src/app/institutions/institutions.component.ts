import {
  Component, OnInit, trigger, state, style, transition, animate, ChangeDetectionStrategy,
  ChangeDetectorRef
} from '@angular/core';
import { TableData } from '../lbd/lbd-table/lbd-table.component';
import { NavbarTitleService } from '../lbd/services/navbar-title.service';
import {WebService} from "../core/web.service";

@Component({
  selector: 'app-news',
  templateUrl: './institutions.component.html',
  styleUrls: ['./institutions.component.css']
})
export class InstitutionsComponent implements OnInit {

  constructor(private change : ChangeDetectorRef,private ws:WebService,private navbarTitleService: NavbarTitleService) {

  }
  ngOnInit() {
    this.navbarTitleService.updateTitle('Institutions');
  }

}
