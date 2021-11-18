import { Component } from "@angular/core";

@Component({
selector: 'app-tour-list',
templateUrl: 'tour-list.component.html',
styleUrls: ['tour-list.component.css']
})
export class TourListComponent {

  Tour: any = {
    "Id": 1,
    "Name": "Lviv tour",
    "Type": "Bus tour",
    "Price": 150
  }

}
