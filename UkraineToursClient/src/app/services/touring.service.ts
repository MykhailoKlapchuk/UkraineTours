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

  getAllTours(): Observable<ITour[]> {
    return this.http.get('data/tours.json').pipe(
      map(data => {
        const jsonData = JSON.stringify(data)
        const toursArray: Array<ITour> = JSON.parse(jsonData)
        return toursArray;
      })
    );
  }
}
