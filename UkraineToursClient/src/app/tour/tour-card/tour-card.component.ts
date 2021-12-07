import { Component, Input } from "@angular/core";
import { ITour } from "../ITour.interface";

@Component({
selector: 'app-tour-card',
templateUrl: 'tour-card.component.html',
styleUrls: ['tour-card.component.css']
})
export class TourCardComponent {
@Input() tour : ITour

}
