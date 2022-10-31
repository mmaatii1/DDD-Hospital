import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable, of, throwError } from 'rxjs';
import { catchError, tap, map } from 'rxjs/operators';
import { Room } from './Room';
import { updateRoom } from './updateRoom';

@Injectable({
  providedIn: 'root'
})
export class RoomService {
  private RoomsUrl = 'http://localhost:57678/api/Room';

  constructor(private http: HttpClient) { }

  getRooms(): Observable<Room[]> {
    return this.http.get<Room[]>(this.RoomsUrl)
      .pipe(
        tap(data => console.log(JSON.stringify(data))),
        catchError(this.handleError)
      );
  }

  getRoom(id: number): Observable<Room> {
    if (id === 0) {
      return of(this.initializeRoom());
    }
    const url = `${this.RoomsUrl}/${id}`;
    return this.http.get<Room>(url)
      .pipe(
        catchError(this.handleError)
      );
  }

  createRoom(Room: Room): Observable<Room> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.post<Room>(this.RoomsUrl, Room, { headers })
      .pipe(
        tap(data => console.log('createRoom: ' + JSON.stringify(data))),
        catchError(this.handleError)
      );
  }

  deleteRoom(id: number): Observable<{}> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    const url = `${this.RoomsUrl}/${id}`;
    return this.http.delete<Room>(url, { headers })
      .pipe(
        tap(data => console.log('deleteRoom: ' + id)),
        catchError(this.handleError)
      );
  }

  updateRoom(Room: Room): Observable<Room> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    const url = `${this.RoomsUrl}/${Room.id}`;
    return this.http.put<Room>(url, Room, { headers })
      .pipe(
        tap(() => console.log('updateRoom: ' + Room.id)),
        // Return the Room on an update
        map(() => Room),
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

  private initializeRoom(): Room {
    // Return an initialized object
    return {
      id: 0,
      roomNumber: 0,
      departmentId: 0,
    };
  }
}
