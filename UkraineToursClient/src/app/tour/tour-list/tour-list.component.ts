import { Component, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { ITourBase } from "src/app/model/itourbase";
import { TouringService } from "src/app/services/touring.service";

@Component({
selector: 'app-tour-list',
templateUrl: 'tour-list.component.html',
styleUrls: ['tour-list.component.css']
})
export class TourListComponent implements OnInit {
  TourForm = 1; //private tour
  tours: Array<ITourBase> = [];

  constructor(private route: ActivatedRoute, private touringService: TouringService){ }

  ngOnInit(): void {
    if(this.route.snapshot.url.toString()){
      this.TourForm = 2; //group tour
    }
    this.touringService.getAllTours(this.TourForm).subscribe(
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
