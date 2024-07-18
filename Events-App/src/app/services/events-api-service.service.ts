import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { environment } from '../../environments/environment';
import { Events } from '../models/events';

@Injectable({
  providedIn: 'root',
})
export class EventsApiServiceService {
  protected APIURL: string = environment.APIURL;

  constructor(private http: HttpClient) {}

  getEvents(): Observable<Events[]> {
    return this.http.get<Events[]>(this.APIURL);
  }

  getEventById(id: number): Observable<Events> {
    return this.http.get<Events>(`${this.APIURL}/${id}`);
  }

  addEvent(event: Events): Observable<Events> {
    return this.http.post<Events>(this.APIURL, event).pipe(
      catchError((error) => {
        console.error('Error adding event:', error);
        return throwError(error);
      })
    );
  }

  updateEvent(event: Events): Observable<Events> {
    return this.http
      .put<Events>(`${this.APIURL}/${event.eventoId}`, event)
      .pipe(
        catchError((error) => {
          console.error('Error updating event:', error);
          return throwError(error);
        })
      );
  }
}
