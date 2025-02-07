import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HealthProfileComponent } from './Componand/health-profile/health-profile.component';
import { HomeComponent } from './Componand/home/home.component';
import { ViewFieldComponent } from './Componand/view-field/view-field.component';
import { View2Component } from './view2/view2.component';

const routes: Routes = [
  {path:"", component:HomeComponent},
  {path:"View", component:ViewFieldComponent},
  {path:"health", component:HealthProfileComponent},
  {path:"view2", component:View2Component}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
