import { Component, OnInit } from "@angular/core";

@Component({
selector: 'app-tour-list',
templateUrl: 'tour-list.component.html',
styleUrls: ['tour-list.component.css']
})
export class TourListComponent implements OnInit {

  tours: Array<any> = [
  {
    "Id": 1,
    "Name": "Lviv bus tour",
    "Type": "Bus tour",
    "Price": 150
  },
  {
    "Id": 2,
    "Name": "Lviv walking tour",
    "Type": "Walking tour",
    "Price": 80
  },
  {
    "Id": 3,
    "Name": "Lviv underground tour",
    "Type": "Walking tour",
    "Price": 100
  },
  {
    "Id": 4,
    "Name": "Karpaty tour",
    "Type": "Bus tour",
    "Price": 300
  },
  {
    "Id": 5,
    "Name": "Synevyr tour",
    "Type": "Bus tour",
    "Price": 300
  },
  {
    "Id": 6,
    "Name": "Bukovel tour",
    "Type": "Hiking tour",
    "Price": 500
  }
]
  constructor(){ }
  ngOnInit(): void {
  }
}
