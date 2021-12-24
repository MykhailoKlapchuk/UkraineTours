import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve, Router, RouterStateSnapshot } from '@angular/router';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Tour } from 'src/app/model/tour';
import { TouringService } from 'src/app/services/touring.service';

@Injectable({
  providedIn: 'root'
})
export class TourDetailResolverService implements Resolve<Tour> {

constructor(private router: Router,  private touringService: TouringService) { }
  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<Tour> | Tour {
    const propId = route.params['id'];
        return this.touringService.getTour(+propId).pipe(
            catchError(error => {
                this.router.navigate(['/']);
                return of(null);
            })
        );
  }
}
