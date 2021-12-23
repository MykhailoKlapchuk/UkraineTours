import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { FormGroup, NgForm } from '@angular/forms';
import { TabsetComponent } from 'ngx-bootstrap/tabs/public_api';
import { Tour } from 'src/app/model/tour';
import { ITourBase } from 'src/app/model/itourbase';

@Component({
  selector: 'app-add-tour',
  templateUrl: './add-tour.component.html',
  styleUrls: ['./add-tour.component.css']
})
export class AddTourComponent implements OnInit {
  @ViewChild('Form') addTourForm: NgForm;
  @ViewChild('formTabs') formTabs?: TabsetComponent;
  addPropertyForm: FormGroup;
  nextClicked: boolean;
  tour = new Tour();

    // Will come from masters
    tourTypes: Array<string> = ['Walking', 'Bus', 'Hiking']
    supportTypes: Array<string> = ['Fully', 'Semi', 'Unsupported']
    settlementList: Array<string> =['Lviv', 'Kyiv'];

    tourView: ITourBase = {
      id: null,
      tourForm: null,
      duration: null,
      name: '',
      tourType: '',
      supportType: '',
      price: null,
      city: '',
      adultsOnly: false
    };


    constructor(private router: Router) { }

    ngOnInit() {
    }

    onBack() {
      this.router.navigate(['/']);
    }

    onSubmit() {
      console.log('Congrats, form Submitted');
      console.log(this.addTourForm);
    }

  selectTab(tabId: number) {
    if (this.formTabs?.tabs[tabId]) {
      this.formTabs.tabs[tabId].active = true;
    }
  }

}
