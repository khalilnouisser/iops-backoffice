import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {ContinentsRoutingModule} from "./countients.routing";
import {FormsModule,ReactiveFormsModule} from "@angular/forms";
import {HttpModule} from "@angular/http";
import {ContinentsComponent} from "./continents.component";
import {WebService} from "../core/web.service";
import {ConfigService} from "../core/config.service";
import {AuthService} from "../core/auth.service";
import {LbdModule} from "../lbd/lbd.module";
import {AgmCoreModule} from "angular2-google-maps/esm/core";
import {RouterModule} from "@angular/router";
import { AddComponent } from './add/add.component';
import { ListComponent } from './list/list.component';
import { NgModel } from "@angular/forms";
import { UpdateComponent } from './update/update.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    HttpModule,
    AgmCoreModule.forRoot({ apiKey: 'AIzaSyAEPDOJl5CPLz6NZcMqJBqZWfVXec3UsJg' }),
    LbdModule,
    ContinentsRoutingModule
  ],
  declarations: [ContinentsComponent, AddComponent, ListComponent, UpdateComponent],
  providers: [AuthService,ConfigService,WebService]
})
export class ContinentsModule { }
