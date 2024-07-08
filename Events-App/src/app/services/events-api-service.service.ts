import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
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
}
