import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { ITourBase } from '../model/itourbase';
import { Tour } from '../model/tour';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class TouringService {

  baseUrl = environment.baseUrl;
  constructor(private http: HttpClient) { }

  getAllCities(): Observable<string[]> {
    return this.http.get<string[]>(this.baseUrl + '/city/cities');
  }

  getAllTours(tourForm?: number): Observable<Tour[]> {
    return this.http.get<Tour[]>(this.baseUrl + '/tour/list/' + tourForm.toString());
  }

  getTour(id: number) {
    return this.http.get<Tour>(this.baseUrl + '/tour/detail/' + id.toString());
  }

  /*getSupportTypes(): Observable<Ikeyvaluepair[]> {
    return this.http.get<Ikeyvaluepair[]>(this.baseUrl + '/suppottype/list');
  }*/

  addTour(tour: Tour) {
/*    const httpOptions = {
      headers: new HttpHeaders({
        Authorization: 'Bearer ' + localStorage.getItem('token')
      })
    };*/
    debugger
    return this.http.post(this.baseUrl + '/tour/add', tour /*httpOptions*/);
  }



  newPropID() {
    if (localStorage.getItem('PID')) {
      localStorage.setItem('PID', String(+localStorage.getItem('PID') + 1));
      return +localStorage.getItem('PID');
    } else {
      localStorage.setItem('PID', '101');
      return 101;
    }
  }
}
