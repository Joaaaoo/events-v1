import { Component, OnInit } from '@angular/core';
import { TableComponent } from '../../components/table/table.component';
import { CommonModule } from '@angular/common';
import { BehaviorSubject, map, Observable } from 'rxjs';
import { Events } from '../../models/events';
import { EventsApiServiceService } from '../../services/events-api-service.service';
import { ButtonModule } from 'primeng/button';
import { ToolbarModule } from 'primeng/toolbar';
import { RouterModule } from '@angular/router';
import { TableModule } from 'primeng/table';
import { SearchComponent } from '../../components/search/search.component';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [
    TableComponent,
    SearchComponent,
    TableModule,
    CommonModule,
    ButtonModule,
    ToolbarModule,
    RouterModule,
  ],
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss',
})
export class HomeComponent implements OnInit {
  events$ = new Observable<Events[]>();

  constructor(private apiService: EventsApiServiceService) {}

  ngOnInit(): void {
    this.receiveEvents();
  }

  receiveEvents() {
    this.events$ = this.apiService.getEvents();
  }
}
