import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';
import { TabsetComponent } from 'ngx-bootstrap/tabs/public_api';
import { Tour } from 'src/app/model/tour';
import { ITourBase } from 'src/app/model/itourbase';
import { AlertifyService } from 'src/app/services/alertify.service';
import { TouringService } from 'src/app/services/touring.service';
import { Ikeyvaluepair } from 'src/app/model/IKeyValuePair';

@Component({
  selector: 'app-add-tour',
  templateUrl: './add-tour.component.html',
  styleUrls: ['./add-tour.component.css']
})
export class AddTourComponent implements OnInit {
  @ViewChild('formTabs') formTabs?: TabsetComponent;
  addTourForm: FormGroup;
  nextClicked: boolean;
  tour = new Tour();

    // Will come from masters
    tourTypes: Ikeyvaluepair [];
    supportTypes: Ikeyvaluepair [];
    settlementList: any =[];

    tourView: ITourBase = {
      id: null,
      tourForm: null,
      tourType: '',
      supportType: '',
      city: '',
      name: '',
      duration: null,
      price: 0,
      adultsOnly: false
    };


    constructor(private fb: FormBuilder,
       private router: Router,
       private alertify: AlertifyService,
       private touringService: TouringService) { }

    ngOnInit() {
      // if(!localStorage.getItem('userName'))
      // {
      //     this.alertify.error('You must be looged in to add a tour');
      //     this.router.navigate(['/user/login']);
      // }
      this.CreateAddTourForm();

      this.touringService.getAllCities().subscribe(data => {
        this.settlementList = data;
      })

      this.touringService.getTourTypes().subscribe(data => {
        this.tourTypes = data;
      })

      this.touringService.getSupportTypes().subscribe(data => {
        this.supportTypes = data;
      })
    }

    CreateAddTourForm(){
      this.addTourForm = this.fb.group({

        BasicInfo: this.fb.group({
            TourForm: [null , Validators.required],
            TourType: [null, Validators.required],
            SupportType: [null, Validators.required],
            Name: [null, Validators.required],
            City: [null, Validators.required]
        }),

        TourPricing: this.fb.group({
            Price: [null, Validators.required],
            SupportPrice: [null],
            TransportationPrice: [null],
            AccommodationPrice: [null],
            FoodPrice: [null],
        }),

        Route: this.fb.group({
            CountryPart: [null, Validators.required],
            Region: [null, Validators.required],
            Settlements: [null],
            Magnets: [null],
        }),

        OtherDetails: this.fb.group({
            AdultsOnly: [null, Validators.required],
            AvailableFrom: [null, Validators.required],
            Duration: [null, Validators.required],
            TransportType: [null],
            AccomType: [null],
            FoodPantion: [null],
            Description: [null]
        })
    });
    }

    onBack() {
      this.router.navigate(['/']);
    }

    onSubmit() {
      this.nextClicked = true;

      if (this.allTabsValid()) {
        this.mapTour();
        this.touringService.addTour(this.tour);
        // .subscribe(
        //   () => {
         this.alertify.success('Congrats, your tour is successfully created');
        // })
      } else {
        this.alertify.error('Please review the form and provide all valid entries');
      }

      console.log(this.addTourForm);
    }

    selectTab(NextTabId: number, IsCurrentTabValid: boolean) {
      this.nextClicked = true;
      if (IsCurrentTabValid) {
          this.formTabs.tabs[NextTabId].active = true;
      }
  }

  mapTour(): void {
    this.tour.id = this.touringService.newPropID();
    this.tour.tourForm = this.TourForm.value;
    this.tour.tourType = this.TourType.value;
    this.tour.supportType = this.SupportType.value;
    this.tour.name = this.Name.value;
    this.tour.city = this.City.value;
    this.tour.price = this.Price.value;
    this.tour.supportPrice = this.SupportType.value;
    this.tour.transportationPrice = this.TransportationPrice.value;
    this.tour.accommodationPrice = this.AccommodationPrice.value;
    this.tour.foodPrice = this.FoodPrice.value;
    this.tour.countryPart = this.CountryPart.value;
    this.tour.region = this.Region.value;
    this.tour.settlements = this.Settlements.value;
    this.tour.magnets = this.Magnets.value;
    this.tour.adultsOnly = this.AdultsOnly.value;
    this.tour.duration = this.Duration.value;
    this.tour.accomType = this.AccomType.value;
    this.tour.transportType = this.TransportType.value;
    this.tour.foodPantion = this.FoodPantion.value;
    //this.tour.availableFrom = this.datePipe.transform(this.AvailableFrom.value,'MM/dd/yyyy');
    this.tour.description = this.Description.value;
}

  // #region <Getter Methods>
    // #region <FormGroups>
  get BasicInfo() {
    return this. addTourForm.controls.BasicInfo as FormGroup;
  }

  get TourPricing() {
    return this. addTourForm.controls.TourPricing as FormGroup;
  }

  get Route() {
    return this. addTourForm.controls.Route as FormGroup;
  }

  get OtherDetails() {
    return this. addTourForm.controls.OtherDetails as FormGroup;
  }
  // #endregion

  // #region <Form Controls Required>
  get TourForm() {
    return this.BasicInfo.controls.TourForm as FormControl;
  }

  get TourType() {
    return this.BasicInfo.controls.TourType as FormControl;
  }

  get SupportType() {
    return this.BasicInfo.controls.SupportType as FormControl;
  }

  get Name() {
    return this.BasicInfo.controls.Name as FormControl;
  }

  get City() {
    return this.BasicInfo.controls.City as FormControl;
  }
  get Price() {
    return this.TourPricing.controls.Price as FormControl;
  }

  get CountryPart() {
    return this.Route.controls.CountryPart as FormControl;
  }

  get Region() {
    return this.Route.controls.Region as FormControl;
  }

  get AdultsOnly() {
    return this.OtherDetails.controls.AdultsOnly as FormControl;
  }

  get AvailableFrom() {
    return this.OtherDetails.controls.AvailableFrom as FormControl;
  }

  get Duration() {
    return this.OtherDetails.controls.Duration as FormControl;
  }
    // #region <Form Controls Optional>
  get SupportPrice() {
    return this.TourPricing.controls.SupportPrice as FormControl;
  }

  get TransportationPrice() {
    return this.TourPricing.controls.TransportationPrice as FormControl;
  }

  get AccommodationPrice() {
    return this.TourPricing.controls.AccommodationPrice as FormControl;
  }

  get FoodPrice() {
    return this.TourPricing.controls.FoodPrice as FormControl;
  }

  get Settlements() {
    return this.Route.controls.Settlements as FormControl;
  }

  get Magnets() {
    return this.Route.controls.Magnets as FormControl;
  }
  get TransportType() {
    return this.OtherDetails.controls.TransportType as FormControl;
  }

  get AccomType() {
    return this.OtherDetails.controls.AccomType as FormControl;
  }

  get FoodPantion() {
    return this.OtherDetails.controls.FoodPantion as FormControl;
  }

  get Description() {
    return this.OtherDetails.controls.Description as FormControl;
  }
    // #endregion
   // #endregion
    // #endregion

    allTabsValid(): boolean {
      if (this.BasicInfo.invalid) {
          this.formTabs.tabs[0].active = true;
          return false;
      }

      if (this.TourPricing.invalid) {
          this.formTabs.tabs[1].active = true;
          return false;
      }

      if (this.Route.invalid) {
          this.formTabs.tabs[2].active = true;
          return false;
      }

      if (this.OtherDetails.invalid) {
          this.formTabs.tabs[3].active = true;
          return false;
      }

        return true;
    }

}
