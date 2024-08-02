import { Component, Input, OnInit } from '@angular/core';
import { TableModule } from 'primeng/table';
import { ButtonModule } from 'primeng/button';
import { ToolbarModule } from 'primeng/toolbar';
import { Observable } from 'rxjs';
import { EventsApiServiceService } from '../../services/events-api-service.service';
import { CommonModule } from '@angular/common';
import { Events } from '../../models/events';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-table',
  standalone: true,
  imports: [
    TableModule,
    ButtonModule,
    ToolbarModule,
    CommonModule,
    RouterModule,
  ],
  templateUrl: './table.component.html',
  styleUrl: './table.component.scss',
})
export class TableComponent {
  @Input() events: Events[] | null = [];
}
