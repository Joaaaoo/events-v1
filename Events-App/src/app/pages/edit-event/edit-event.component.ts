import { Component, OnInit } from '@angular/core';
import { EventsApiServiceService } from '../../services/events-api-service.service';
import { CommonModule } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-edit-event',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './edit-event.component.html',
  styleUrl: './edit-event.component.scss',
})
export class EditEventComponent implements OnInit {
  idPage: number;
  eventData$ = new Observable<any>();

  constructor(
    private apiService: EventsApiServiceService,
    private activeRoute: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.getEventById();
  }

  getEventById() {
    this.idPage = this.activeRoute.snapshot.params.id;
    this.eventData$ = this.apiService.getEventById(this.idPage);
  }
}
