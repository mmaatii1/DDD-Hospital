import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable, of, throwError } from 'rxjs';
import { catchError, tap, map } from 'rxjs/operators';
import { Department } from './department';

@Injectable({
  providedIn: 'root'
})
export class DepartmentService {
  private departmentsUrl = 'http://localhost:57678/api/Department';

  constructor(private http: HttpClient) { }

  getDepartments(): Observable<Department[]> {
    return this.http.get<Department[]>(this.departmentsUrl)
      .pipe(
        tap(data => console.log(JSON.stringify(data))),
        catchError(this.handleError)
      );
  }

  getDepartment(id: number): Observable<Department> {
    if (id === 0) {
      return of(this.initializeDepartment());
    }
    const url = `${this.departmentsUrl}/${id}`;
    return this.http.get<Department>(url)
      .pipe(
        catchError(this.handleError)
      );
  }

  createDepartment(department: Department): Observable<Department> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.post<Department>(this.departmentsUrl, department, { headers })
      .pipe(
        tap(data => console.log('createDepartment: ' + JSON.stringify(data))),
        catchError(this.handleError)
      );
  }

  deleteDepartment(id: number): Observable<{}> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    const url = `${this.departmentsUrl}/${id}`;
    return this.http.delete<Department>(url, { headers })
      .pipe(
        tap(data => console.log('deleteDepartment: ' + id)),
        catchError(this.handleError)
      );
  }

  updateDepartment(department: Department): Observable<Department> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    const url = `${this.departmentsUrl}/${department.id}`;
    return this.http.put<Department>(url, department, { headers })
      .pipe(
        tap(() => console.log('updateDepartment: ' + department.id)),
        // Return the Department on an update
        map(() => department),
        catchError(this.handleError)
      );
  }

  private handleError(err: any) {
    // in a real world app, we may send the server to some remote logging infrastructure
    // instead of just logging it to the console
    let errorMessage: string;
    if (err.error instanceof ErrorEvent) {
      // A client-side or network error occurred. Handle it accordingly.
      errorMessage = `An error occurred: ${err.error.message}`;
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong,
      errorMessage = `Backend returned code ${err.status}: ${err.body.error}`;
    }
    console.error(err);
    return throwError(errorMessage);
  }

  private initializeDepartment(): Department {
    // Return an initialized object
    return {
      id: 0,
      name: '',
      description: ''
    };
  }
}
