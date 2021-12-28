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
  Today = new Date();
  City = '';
  SearchCity = '';
  SortbyParam = '';
  SortDirection = 'asc';

  constructor(private route: ActivatedRoute, private touringService: TouringService){ }


    ngOnInit(): void {
        if (this.route.snapshot.url.toString()) {
            this.TourForm = 2; // Means we are on rent-property URL else we are on base URL
        }
        this.touringService.getAllTours(this.TourForm).subscribe(
            data => {
                this.tours = data;
                console.log(data);
            }, error => {
                console.log('httperror:');
                console.log(error);
            }
        );
    }

    onCityFilter() {
        this.SearchCity = this.City;
    }

    onCityFilterClear() {
        this.SearchCity = '';
        this.City = '';
    }

    onSortDirection() {
        if (this.SortDirection === 'desc') {
            this.SortDirection = 'asc';
        } else {
            this.SortDirection = 'desc';
        }
    }

}

