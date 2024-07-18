import { Component, OnInit } from '@angular/core';
import { ReturnBtnComponent } from '../../components/return-btn/return-btn.component';
import { FeaturedComponent } from '../featured/featured.component';
import {
  FormBuilder,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
} from '@angular/forms';
import { CommonModule } from '@angular/common';
import { InputTextModule } from 'primeng/inputtext';
import { EventsApiServiceService } from '../../services/events-api-service.service';
import { Events } from '../../models/events';

@Component({
  selector: 'app-add-event',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    InputTextModule,
    ReturnBtnComponent,
    FeaturedComponent,
  ],
  templateUrl: './add-event.component.html',
  styleUrl: './add-event.component.scss',
})
export class AddEventComponent implements OnInit {
  formulario: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private eventsService: EventsApiServiceService
  ) {}

  ngOnInit(): void {
    this.criarFormulario();
  }
  criarFormulario() {
    this.formulario = this.formBuilder.group({
      theme: [null],
    });
  }

  salvarDados() {
    const event: Events = this.formulario.value;
    this.eventsService.addEvent(event).subscribe(
      (response) => {
        console.log('Event added successfully:', response);
        // redirecionar ou exibir uma mensagem de sucesso
      },
      (error) => {
        console.error('Error adding event:', error);
        // exibir uma mensagem de erro
      }
    );
  }
}
