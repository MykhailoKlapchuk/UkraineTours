import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {HttpClientModule} from '@angular/common/http';
import { Routes, RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {BsDropdownModule} from 'ngx-bootstrap/dropdown';

import { AppComponent } from './app.component';
import { TourCardComponent } from './tour/tour-card/tour-card.component';
import { TourListComponent } from './tour/tour-list/tour-list.component';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { TouringService } from './services/touring.service';
import { AddTourComponent } from './tour/add-tour/add-tour.component';
import { TourDetailComponent } from './tour/tour-detail/tour-detail.component';
import { UserRegisterComponent } from './user/user-register/user-register.component';
import { UserLoginComponent } from './user/user-login/user-login.component';
import { UserServiceService } from './services/user-service.service';
import { AlertifyService } from './services/alertify.service';

const appRoutes: Routes = [
  {path: '', component: TourListComponent},
  {path: 'group-tour', component: TourListComponent},
  {path: 'add-tour', component: AddTourComponent},
  {path: 'tour-detail/:id', component: TourDetailComponent},
  {path: 'user/login', component: UserLoginComponent},
  {path: 'user/register', component: UserRegisterComponent},
  {path: '**', component: TourListComponent}
]

@NgModule({
  declarations: [
    AppComponent,
    TourCardComponent,
    TourListComponent,
    NavBarComponent,
    AddTourComponent,
    TourDetailComponent,
    UserRegisterComponent,
    UserLoginComponent
   ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot(appRoutes),
    BrowserAnimationsModule,
    BsDropdownModule.forRoot()
  ],
  providers: [
    TouringService,
    UserServiceService,
    AlertifyService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
