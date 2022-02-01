import {
  HttpErrorResponse,
  HttpHandler,
  HttpInterceptor,
  HttpRequest,
} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of, throwError } from 'rxjs';
import { catchError, concatMap, retry, retryWhen } from 'rxjs/operators';
import { ErrorCode } from '../model/enums';
import { AlertifyService } from './alertify.service';

@Injectable({
  providedIn: 'root',
})
export class HttpErrorInterceptorService implements HttpInterceptor {
  constructor(private alertify: AlertifyService) {}

  intercept(request: HttpRequest<any>, next: HttpHandler) {
    console.log('HTTP Request started');

    return next.handle(request).pipe(
      retryWhen((error) => this.retryRequest(error, 10)),
      catchError((error: HttpErrorResponse) => {
        const errorMessage = this.setError(error);
        this.alertify.error(errorMessage);
        return throwError(errorMessage);
      })
    );
  }

  // Retry the request in case of errror
  retryRequest(error: Observable<unknown>, retryCount: number): Observable<unknown> {
    return error.pipe(
      concatMap((checkErr: HttpErrorResponse, count: number) => {
        if (count <= retryCount && checkErr.status === ErrorCode.serverDown) {
          return of(checkErr);
        }
        return throwError(checkErr);
      })
    );
  }

  setError(error: HttpErrorResponse): string {
    let errorMessage = 'Unknown error occured';
    if (error.error instanceof ErrorEvent) {
      // Client side error
      errorMessage = error.error.message;
    } else {
      // server side error
      if (error.status === ErrorCode.unauthorised) {
        return error.error.errorMessage;
      }

      if (error.error.errorMessage && error.status !== ErrorCode.serverDown) {
        {
          errorMessage = error.error.errorMessage;
        }
      }
    }
    return errorMessage;
  }
}
