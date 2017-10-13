import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {FormsModule,ReactiveFormsModule} from "@angular/forms";
import {HttpModule} from "@angular/http";
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
import {ImageUploadModule} from "angular2-image-upload";
import {InstitutionsComponent} from "./institutions.component";
import {InstitutionsRouting} from "./institutions.routing";

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    HttpModule,
    AgmCoreModule.forRoot({ apiKey: 'AIzaSyAEPDOJl5CPLz6NZcMqJBqZWfVXec3UsJg' }),
    LbdModule,
    InstitutionsRouting,
    ImageUploadModule.forRoot(),
  ],
  declarations: [InstitutionsComponent, AddComponent, ListComponent, UpdateComponent],
})
export class InstitutionsModule { }
