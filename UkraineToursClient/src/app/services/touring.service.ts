import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import {map} from 'rxjs/operators';
import { Observable } from 'rxjs';
import { ITourBase } from '../model/itourbase';
import { Tour } from '../model/tour';

@Injectable({
  providedIn: 'root'
})
export class TouringService {

  constructor(private http:HttpClient) { }

  getAllTours(TourForm: number): Observable<ITourBase[]>  {
    return this.http.get('data/tours.json').pipe(
      map(data => {
        const toursArray: Array<ITourBase> = [];
        for (const id in data) {
          if (data.hasOwnProperty(id) && data[id].tourForm === TourForm) {
            toursArray.push(data[id]);
          }
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
}
