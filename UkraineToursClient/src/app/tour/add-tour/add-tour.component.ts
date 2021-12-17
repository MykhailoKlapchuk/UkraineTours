import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-tour',
  templateUrl: './add-tour.component.html',
  styleUrls: ['./add-tour.component.css']
})
export class AddTourComponent implements OnInit {
  @ViewChild('Form') addTourForm: NgForm;
  constructor(private route: Router) { }

  ngOnInit() {
  }

  onBack(){
    this.route.navigate(['/'])
  }

  onSubmit(){
    console.log(this.addTourForm);

  }

}
