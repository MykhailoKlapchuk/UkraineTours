import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {HttpClientModule} from '@angular/common/http';

import { AppComponent } from './app.component';
import { TourCardComponent } from './tour/tour-card/tour-card.component';
import { TourListComponent } from './tour/tour-list/tour-list.component';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { TouringService } from './services/touring.service';

@NgModule({
  declarations: [
    AppComponent,
    TourCardComponent,
    TourListComponent,
      NavBarComponent
   ],
  imports: [
    BrowserModule,
    HttpClientModule
  ],
  providers: [
    TouringService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
