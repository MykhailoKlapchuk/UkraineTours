import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Tour } from 'src/app/model/tour';
import { TouringService } from 'src/app/services/touring.service';

@Component({
  selector: 'app-tour-detail',
  templateUrl: './tour-detail.component.html',
  styleUrls: ['./tour-detail.component.css']
})
export class TourDetailComponent implements OnInit {
tour = new Tour();
public mainPhotoUrl: string = null;

  constructor(private route: ActivatedRoute,
    private router: Router,
    private touringService: TouringService) { }

  ngOnInit() {
    this.route.data.subscribe(
      (data: Tour) => {
          this.tour = data['tour'];
          this.mainPhotoUrl = this.tour.photo;
      })
  }
}
