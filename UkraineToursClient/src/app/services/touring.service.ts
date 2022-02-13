import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable } from 'rxjs';
import { Tour } from '../model/tour';
import { environment } from '../../environments/environment';
import { Ikeyvaluepair } from '../model/ikeyvaluepair';

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

  getSupportTypes(): Observable<Ikeyvaluepair[]> {
    return this.http.get<Ikeyvaluepair[]>(this.baseUrl + '/supporttype/list');
  }

  getTourTypes(): Observable<Ikeyvaluepair[]> {
    return this.http.get<Ikeyvaluepair[]>(this.baseUrl + '/tourtype/list');
  }

  addTour(tour: Tour) {
    const httpOptions = {
      headers: new HttpHeaders({
        Authorization: 'Bearer ' + localStorage.getItem('token')
      })
    };
    return this.http.post(this.baseUrl + '/tour/add', tour, httpOptions);
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
