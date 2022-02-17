import { error } from '@angular/compiler/src/util';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Photo } from 'src/app/model/photo';
import { Tour } from 'src/app/model/tour';
import { TouringService } from 'src/app/services/touring.service';

@Component({
  selector: 'app-tour-detail',
  templateUrl: './tour-detail.component.html',
  styleUrls: ['./tour-detail.component.css']
})
export class TourDetailComponent implements OnInit {
public tourId: number;
tour = new Tour();
public mainPhotoUrl: string = null;

  constructor(private route: ActivatedRoute,
    private router: Router,
    private touringService: TouringService) { }

  ngOnInit() {
    this.tourId = +this.route.snapshot.params['id'];
    this.route.data.subscribe(
      (data: Tour) => {
          this.tour = data['tour'];
          this.mainPhotoUrl = this.tour.photo;
          //this.tour.photos = this.getTourPhotos();
          console.log(this.tour.photos);
      })
  }

  getTourPhotos(): Photo[] {
    const photoUrls: Photo[] = [
      {
        imageUrl: "assets/images/bus_lviv.jpg",
        isPrimary: true,
        publicId: '1'
      },
      {
        imageUrl: "assets/images/underground_lviv.jpg",
        isPrimary: false,
        publicId: '2'
      },
      {
        imageUrl: "assets/images/lviv.jpg",
        isPrimary: false,
        publicId: '3'
      }
    ];
    return photoUrls;
  }
}
