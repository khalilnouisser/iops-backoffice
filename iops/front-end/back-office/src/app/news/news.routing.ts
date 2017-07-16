/**
 * Created by khalilnouisser on 7/16/17.
 */
/**
 * Created by khalilnouisser on 7/15/17.
 */
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {NewsComponent} from "./news.component";
import {WebService} from "../core/web.service";
import {ConfigService} from "../core/config.service";
import {AuthService} from "../core/auth.service";
import {AddComponent} from "./add/add.component";
import {ListComponent} from "./list/list.component";
import {UpdateComponent} from "./update/update.component";

const routes: Routes = [{path: 'news',component:NewsComponent,children:[
  {path: '' , redirectTo:'list',pathMatch:"full"},
  {path: 'add',component:AddComponent},
  {path: 'list',component:ListComponent},
  { path: 'update/:id',component: UpdateComponent },
]}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
  providers: [AuthService,ConfigService,WebService],
})
export class NewsRoutingModule { }
