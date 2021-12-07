import { Component, OnInit } from "@angular/core";
import { TouringService } from "src/app/services/touring.service";
import { ITour } from "../ITour.interface";

@Component({
selector: 'app-tour-list',
templateUrl: 'tour-list.component.html',
styleUrls: ['tour-list.component.css']
})
export class TourListComponent implements OnInit {

  tours: Array<ITour> = [];

  constructor(private touringService: TouringService){ }

  ngOnInit(): void {
    this.touringService.getAllTours().subscribe(
      data=> {
        this.tours = data;
        console.log(data);
      }, error => {
        console.log(error);
        console.log('httperror:');
      }
    );
  }
}
