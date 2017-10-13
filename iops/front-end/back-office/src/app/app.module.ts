import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule, Routes } from '@angular/router';
import { AgmCoreModule } from 'angular2-google-maps/core';

import { AppComponent } from './app.component';
import { FooterLayoutComponent } from './footer-layout/footer-layout.component';
import { LbdModule } from './lbd/lbd.module';
import { DashboardComponent } from './dashboard/dashboard.component';
import { UserComponent } from './user/user.component';
import { TableComponent } from './table/table.component';
import { TypographyComponent } from './typography/typography.component';
import { IconsComponent } from './icons/icons.component';
import { MapsComponent } from './maps/maps.component';
import { NotificationsComponent } from './notifications/notifications.component';
import { LoginComponent } from './login/login.component';
import {AuthService} from "./core/auth.service";
import {ConfigService} from "./core/config.service";
import { ContinentsComponent } from './continents/continents.component';
import {WebService} from "./core/web.service";
import {ContinentsModule} from "./continents/continents.module";
import { MessagesComponent } from './messages/messages.component';
import {DateService} from "./core/date.service";
import { NewsComponent } from './news/news.component';
import {NewsModule} from "./news/news.module";
import {GeneralService} from "./core/general.service";
import { AdminsComponent } from './admins/admins.component';
import {CountriesModule} from "./countries/continents.module";
import {ContestantsComponent} from "./contestants/contestants.component";
import {InstitutionsRouting} from "./institutions/institutions.routing";
import {InstitutionsModule} from "./institutions/institutions.module";
const appRoutes: Routes = [
  { path: 'maps', component: MapsComponent },
  {
    path: '', component: FooterLayoutComponent, children:
    [
      { path: 'dashboard', component: DashboardComponent },
      { path: 'messages', component: MessagesComponent },
      { path: 'user', component: UserComponent },
      { path: 'table', component: TableComponent },
      { path: 'typography', component: TypographyComponent },
      { path: 'icons', component: IconsComponent },
      { path: 'admins', component: AdminsComponent },
      { path: 'contestants', component: ContestantsComponent },
      { path: 'notifications', component: NotificationsComponent },
      { path: '**', redirectTo: 'dashboard' }
    ]
  }
];

@NgModule({
  declarations: [
    AppComponent,
    FooterLayoutComponent,
    DashboardComponent,
    UserComponent,
    TableComponent,
    TypographyComponent,
    IconsComponent,
    MapsComponent,
    NotificationsComponent,
    LoginComponent,
    MessagesComponent,
    AdminsComponent,
    ContestantsComponent

  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    RouterModule.forRoot(appRoutes),
    AgmCoreModule.forRoot({ apiKey: 'AIzaSyAEPDOJl5CPLz6NZcMqJBqZWfVXec3UsJg' }),
    LbdModule,
    ContinentsModule,
    CountriesModule,
    NewsModule,
    InstitutionsModule
  ],
  providers: [AuthService,ConfigService,WebService,DateService,GeneralService],
  bootstrap: [AppComponent]
})
export class AppModule { }
