import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {HttpClientModule} from '@angular/common/http';
import { Routes, RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { TourCardComponent } from './tour/tour-card/tour-card.component';
import { TourListComponent } from './tour/tour-list/tour-list.component';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { TouringService } from './services/touring.service';
import { AddTourComponent } from './tour/add-tour/add-tour.component';
import { TourDetailComponent } from './tour/tour-detail/tour-detail.component';

const appRoutes: Routes = [
  {path: '', component: TourListComponent},
  {path: 'group-tour', component: TourListComponent},
  {path: 'add-tour', component: AddTourComponent},
  {path: 'tour-detail/:id', component: TourDetailComponent},
  {path: '**', component: TourListComponent}
]

@NgModule({
  declarations: [
    AppComponent,
    TourCardComponent,
    TourListComponent,
    NavBarComponent,
    AddTourComponent,
    TourDetailComponent
   ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot(appRoutes)
  ],
  providers: [
    TouringService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
