import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { Routes, RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { ButtonsModule } from 'ngx-bootstrap/buttons';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { CarouselModule } from 'ngx-bootstrap/carousel';
import { AppComponent } from './app.component';
import { TourCardComponent } from './tour/tour-card/tour-card.component';
import { TourListComponent } from './tour/tour-list/tour-list.component';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { TouringService } from './services/touring.service';
import { AddTourComponent } from './tour/add-tour/add-tour.component';
import { TourDetailComponent } from './tour/tour-detail/tour-detail.component';
import { UserRegisterComponent } from './user/user-register/user-register.component';
import { UserLoginComponent } from './user/user-login/user-login.component';
import { AlertifyService } from './services/alertify.service';
import { AuthService } from './services/auth.service';
import { FilterPipe } from './Pipes/filter.pipe';
import { SortPipe } from './Pipes/sort.pipe';
import { HttpErrorInterceptorService } from './services/httperor-interceptor.service';
import { DatePipe } from '@angular/common';
import { TourDetailResolverService } from './tour/tour-detail/tour-detail-resolver.service';

const appRoutes: Routes = [
  { path: '', component: TourListComponent },
  { path: 'group-tour', component: TourListComponent },
  { path: 'add-tour', component: AddTourComponent },
  {
    path: 'tour-detail/:id',
    component: TourDetailComponent,
    resolve: { tour: TourDetailResolverService },
  },
  { path: 'user/login', component: UserLoginComponent },
  { path: 'user/register', component: UserRegisterComponent },
  { path: '**', component: TourListComponent },
];

@NgModule({
  declarations: [
    AppComponent,
    TourCardComponent,
    TourListComponent,
    NavBarComponent,
    AddTourComponent,
    TourDetailComponent,
    UserRegisterComponent,
    UserLoginComponent,
    FilterPipe,
    SortPipe,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot(appRoutes),
    BrowserAnimationsModule,
    BsDropdownModule.forRoot(),
    TabsModule.forRoot(),
    ButtonsModule.forRoot(),
    BsDatepickerModule.forRoot(),
    CarouselModule.forRoot(),
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: HttpErrorInterceptorService,
      multi: true,
    },
    DatePipe,
    TouringService,
    AlertifyService,
    AuthService,
    TourDetailResolverService,
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
