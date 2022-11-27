import { Injectable } from "@angular/core";
import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest, HttpErrorResponse } from '@angular/common/http';
import { Observable, of, throwError } from "rxjs";
import { catchError, map } from 'rxjs/operators';
import { Router } from '@angular/router';

@Injectable()
export class GlobalHttpInterceptorService implements HttpInterceptor {

  constructor(public router: Router) {
  }

  //1.  No Errors
  intercept1(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    return next.handle(req).pipe(
      catchError((error) => {
        console.log('error in intercept')
        console.error(error);
        return throwError(error.message);
      })
    )
  }



  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    const token: string = 'invald token';
    req = req.clone({ headers: req.headers.set('Authorization', 'Bearer ' + token) });

    return next.handle(req).pipe(
      catchError((error) => {

        let handled: boolean = false;
        console.error(error);
        if (error instanceof HttpErrorResponse) {
          if (error.error instanceof ErrorEvent) {
            console.error("Error Event");
          } else {
            console.log(`error status : ${error.status} ${error.statusText}`);
            switch (error.status) {
              case 400:      
                this.router.navigateByUrl("/bad-request");
                console.log(`redirect to bad request page`);
                handled = true;
                break;
              case 404:     
                this.router.navigateByUrl("/not-found");
                console.log(`redirect to not found page`);
                handled = true;
                break;
              default:
                this.router.navigateByUrl("/server-error");
                handled = true;
                break;
            }
          }
        }
        else {
          console.error("Other Errors");
        }

        if (handled) {
          console.log('return back ');
          return of(error);
        } else {
          console.log('throw error back to to the subscriber');
          return throwError(error);
        }

      })
    )
  }
}