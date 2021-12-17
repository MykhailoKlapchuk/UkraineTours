import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-tour-detail',
  templateUrl: './tour-detail.component.html',
  styleUrls: ['./tour-detail.component.css']
})
export class TourDetailComponent implements OnInit {
public tourId: number;
  constructor(private route: ActivatedRoute, private router: Router) { }

  ngOnInit() {
    this.tourId = +this.route.snapshot.params['id'];

    this.route.params.subscribe(
      (params) => {
        this.tourId = +params['id'];
      }
    )
  }

  onSelectNext(){
    this.tourId += 1;
    this.router.navigate(['tour-detail', this.tourId]);
  }

}
