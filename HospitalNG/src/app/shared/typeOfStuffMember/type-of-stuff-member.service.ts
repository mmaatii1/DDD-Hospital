import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable, of, throwError } from 'rxjs';
import { catchError, tap, map } from 'rxjs/operators';
import { TypeOfStuffMember } from './typeOfStuffMember';

@Injectable({
  providedIn: 'root'
})
export class TypeOfStuffMemberService {
  private typeOfStuffMembersUrl = 'http://localhost:57678/api/typeOfStuffMember';

  constructor(private http: HttpClient) { }

  getTypeOfStuffMembers(): Observable<TypeOfStuffMember[]> {
    return this.http.get<TypeOfStuffMember[]>(this.typeOfStuffMembersUrl)
      .pipe(
        tap(data => console.log(JSON.stringify(data))),
        catchError(this.handleError)
      );
  }

  getTypeOfStuffMember(id: number): Observable<TypeOfStuffMember> {
    if (id === 0) {
      return of(this.initializeTypeOfStuffMember());
    }
    const url = `${this.typeOfStuffMembersUrl}/${id}`;
    return this.http.get<TypeOfStuffMember>(url)
      .pipe(
        catchError(this.handleError)
      );
  }

  createTypeOfStuffMember(typeOfStuffMember: TypeOfStuffMember): Observable<TypeOfStuffMember> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.post<TypeOfStuffMember>(this.typeOfStuffMembersUrl, typeOfStuffMember, { headers })
      .pipe(
        tap(data => console.log('createTypeOfStuffMember: ' + JSON.stringify(data))),
        catchError(this.handleError)
      );
  }

  deleteTypeOfStuffMember(id: number): Observable<{}> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    const url = `${this.typeOfStuffMembersUrl}/${id}`;
    return this.http.delete<TypeOfStuffMember>(url, { headers })
      .pipe(
        tap(data => console.log('deleteTypeOfStuffMember: ' + id)),
        catchError(this.handleError)
      );
  }

  updateTypeOfStuffMember(typeOfStuffMember: TypeOfStuffMember): Observable<TypeOfStuffMember> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    const url = `${this.typeOfStuffMembersUrl}/${typeOfStuffMember.id}`;
    return this.http.put<TypeOfStuffMember>(url, typeOfStuffMember, { headers })
      .pipe(
        tap(() => console.log('updateTypeOfStuffMember: ' + typeOfStuffMember.id)),
        // Return the typeOfStuffMember on an update
        map(() => typeOfStuffMember),
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

  private initializeTypeOfStuffMember(): TypeOfStuffMember {
    // Return an initialized object
    return {
      id: 0,
      name: '',
      description: ''
    };
  }
}

