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
public tourId: number;
tour = new Tour();
public mainPhotoUrl: string = null;
//galleryOptions: NgxGalleryOptions[];
//galleryImages: NgxGalleryImage[];

  constructor(private route: ActivatedRoute,
    private router: Router,
    private touringService: TouringService) { }

  ngOnInit() {
    this.tourId = +this.route.snapshot.params['id'];

    this.route.params.subscribe(
      (params) => {
        this.tourId = +params['id'];
        this.touringService.getTour(this.tourId).subscribe(
          (data: Tour) => {
            this.tour = data;
          }
        )
      }
    )
    // this.galleryOptions = [
    //   {
    //       width: '100%',
    //       height: '465px',
    //       thumbnailsColumns: 4,
    //       imageAnimation: NgxGalleryAnimation.Slide,
    //       preview: true
    //   }
  //];

  //this.galleryImages = this.getPropertyPhotos();

  }

//   getPropertyPhotos(): NgxGalleryImage[] {
//     const photoUrls: NgxGalleryImage[] = [];
//     for (const photo of this.property.photos) {
//         if(photo.isPrimary)
//         {
//             this.mainPhotoUrl = photo.imageUrl;
//         }
//         else{
//             photoUrls.push(
//                 {
//                     small: photo.imageUrl,
//                     medium: photo.imageUrl,
//                     big: photo.imageUrl
//                 }
//             );}
//     }
//     return photoUrls;
// }



}
