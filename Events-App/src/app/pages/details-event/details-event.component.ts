import { Component, OnInit } from '@angular/core';
import { ReturnBtnComponent } from '../../components/return-btn/return-btn.component';
import { ChipModule } from 'primeng/chip';
import { Observable } from 'rxjs';
import { EventsApiServiceService } from '../../services/events-api-service.service';
import { ActivatedRoute } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-details-event',
  standalone: true,
  imports: [ReturnBtnComponent, ChipModule, CommonModule],
  templateUrl: './details-event.component.html',
  styleUrl: './details-event.component.scss',
})
export class DetailsEventComponent implements OnInit {
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
