import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import {map} from 'rxjs/operators';
import { Observable } from 'rxjs';
import { ITourBase } from '../model/itourbase';
import { Tour } from '../model/tour';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class TouringService {

  baseUrl = environment.baseUrl;
  constructor(private http:HttpClient) { }

getAllCities(): Observable<string[]>{
  return this.http.get<string[]>(this.baseUrl + '/city/cities');
}

  getAllTours(TourForm?: number): Observable<Tour[]>  {
    return this.http.get('data/tours.json').pipe(
      map(data => {
        const toursArray: Array<Tour> = [];
        for (const id in data) {
            toursArray.push(data[id]);
        }
        return toursArray;
      })
    );
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

  addTour(tour:Tour){
    localStorage.setItem('newTour', JSON.stringify(tour))
  }

  getTour(id: number){
    return this.getAllTours().pipe(
      map(tourArray =>{
        return tourArray.find(t => t.id === id)
      })
    );
  }
}
