import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import {map} from 'rxjs/operators';
import { ITour } from '../tour/ITour.interface';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TouringService {

  constructor(private http:HttpClient) { }

  getAllTours(TourForm: number): Observable<ITour[]>  {
    return this.http.get('data/tours.json').pipe(
      map(data => {
        const toursArray: Array<ITour> = [];
        for (const id in data) {
          if (data.hasOwnProperty(id) && data[id].Form === TourForm) {
            toursArray.push(data[id]);
          }
        }
        return toursArray;
      })
    );
  }
}
