import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of, throwError } from 'rxjs';
import { catchError, tap, map } from 'rxjs/operators';
import { StuffMember } from './stuffMember';
@Injectable({
  providedIn: 'root'
})
export class StuffMemberService {

  private stuffMembersUrl = 'http://localhost:57678/api/StuffMember';

  constructor(private http: HttpClient) { }

  getStuffMembers(): Observable<StuffMember[]> {
    return this.http.get<StuffMember[]>(this.stuffMembersUrl)
      .pipe(
        tap(data => console.log(JSON.stringify(data))),
        catchError(this.handleError)
      );
  }

  

  createStuffMember(StuffMember: StuffMember): Observable<StuffMember> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.post<StuffMember>(this.stuffMembersUrl, StuffMember, { headers })
      .pipe(
        tap(data => console.log('createStuffMember: ' + JSON.stringify(data))),
        catchError(this.handleError)
      );
  }

  deleteStuffMember(id: number): Observable<{}> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    const url = `${this.stuffMembersUrl}/${id}`;
    return this.http.delete<StuffMember>(url, { headers })
      .pipe(
        tap(data => console.log('deleteStuffMember: ' + id)),
        catchError(this.handleError)
      );
  }
  
  getStuffMember(id: number): Observable<StuffMember> {
    if (id === 0) {
      return of(this.initializeStuffMember());
    }
    const url = `${this.stuffMembersUrl}/${id}`;
    return this.http.get<StuffMember>(url)
      .pipe(
        catchError(this.handleError)
      );
  }

  updateStuffMember(stuffMember: StuffMember): Observable<StuffMember> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    const url = `${this.stuffMembersUrl}/${stuffMember.id}`;
    return this.http.put<StuffMember>(url, stuffMember, { headers })
      .pipe(
        tap(() => console.log('updateStuffMember: ' + stuffMember.id)),
        // Return the StuffMember on an update
        map(() => stuffMember),
        catchError(this.handleError)
      );
  }

  private handleError(err: any) {
    let errorMessage: string;
    if (err.error instanceof ErrorEvent) {
      errorMessage = `An error occurred: ${err.error.message}`;
    } else {
      errorMessage = `Backend returned code ${err.status}: ${err.body.error}`;
    }
    console.error(err);
    return throwError(errorMessage);
  }

  private initializeStuffMember(): StuffMember {
    // Return an initialized object
    return {
      id : 0,
      departmentId: 0,
      departmentName: '',
      departmentDescription: '',
      typeOfStuffMemberId: 0,
      typeOfStuffMemberName: '',
      typeOfStuffMemberDescription: '',
      firstName: '',
      lastName: '',
    };
  }
}

