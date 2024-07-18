import { Component, OnInit } from '@angular/core';
import { EventsApiServiceService } from '../../services/events-api-service.service';
import { CommonModule } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { ReturnBtnComponent } from '../../components/return-btn/return-btn.component';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { Events } from '../../models/events';

@Component({
  selector: 'app-edit-event',
  standalone: true,
  imports: [CommonModule, ReturnBtnComponent, ReactiveFormsModule],
  templateUrl: './edit-event.component.html',
  styleUrl: './edit-event.component.scss',
})
export class EditEventComponent implements OnInit {
  idPage: number;
  eventData$ = new Observable<any>();
  formulario: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private apiService: EventsApiServiceService,
    private activeRoute: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.idPage = this.activeRoute.snapshot.params.id;
    this.criarFormulario();
    this.getEventById();
  }

  criarFormulario() {
    this.formulario = this.formBuilder.group({
      theme: [null],
    });
  }

  getEventById() {
    this.apiService.getEventById(this.idPage).subscribe((event) => {
      this.populateForm(event);
    });
  }

  populateForm(event: Events) {
    this.formulario.patchValue(event);
  }
  salvarDados() {
    const event: Events = { ...this.formulario.value, eventoId: this.idPage };
    this.apiService.updateEvent(event).subscribe(
      (response) => {
        console.log('Event updated successfully:', response);
        // redirecionar ou exibir uma mensagem de sucesso
      },
      (error) => {
        console.error('Error updating event:', error);
        // exibir uma mensagem de erro
      }
    );
  }
}
