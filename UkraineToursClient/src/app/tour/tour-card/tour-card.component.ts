import { Component, Input } from "@angular/core";
import { ITourBase } from "src/app/model/itourbase";

@Component({
selector: 'app-tour-card',
templateUrl: 'tour-card.component.html',
styleUrls: ['tour-card.component.css']
})
export class TourCardComponent {
@Input() tour : ITourBase;
@Input() hideIcons: boolean;

}
