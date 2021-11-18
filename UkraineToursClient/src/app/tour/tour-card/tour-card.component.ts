import { Component } from "@angular/core";

@Component({
selector: 'app-tour-card',
templateUrl: 'tour-card.component.html',
styleUrls: ['tour-card.component.css']
})
export class TourCardComponent {
  Tour: any = {
    "Id": 1,
    "Name": "Lviv tour",
    "Type": "Bus tour",
    "Price": 150
  }

}
