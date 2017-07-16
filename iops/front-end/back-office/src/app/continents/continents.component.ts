import {
  Component, OnInit, trigger, state, style, transition, animate, ChangeDetectionStrategy,
  ChangeDetectorRef
} from '@angular/core';
import { TableData } from '../lbd/lbd-table/lbd-table.component';
import { NavbarTitleService } from '../lbd/services/navbar-title.service';
import {WebService} from "../core/web.service";

@Component({
  selector: 'app-continents',
  templateUrl: './continents.component.html',
  styleUrls: ['./continents.component.css'],
  changeDetection:ChangeDetectionStrategy.Default
})
export class ContinentsComponent implements OnInit{

  constructor(private change : ChangeDetectorRef,private ws:WebService,private navbarTitleService: NavbarTitleService) {

  }

  public ngOnInit() {
    this.navbarTitleService.updateTitle('Continents');

  }

}
