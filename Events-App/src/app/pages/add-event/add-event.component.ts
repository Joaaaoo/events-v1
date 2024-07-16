import { Component } from '@angular/core';
import { ReturnBtnComponent } from '../../components/return-btn/return-btn.component';
import { FeaturedComponent } from '../featured/featured.component';

@Component({
  selector: 'app-add-event',
  standalone: true,
  imports: [ReturnBtnComponent, FeaturedComponent],
  templateUrl: './add-event.component.html',
  styleUrl: './add-event.component.scss',
})
export class AddEventComponent {}
