import { Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { AddEventComponent } from './pages/add-event/add-event.component';
import { EditEventComponent } from './pages/edit-event/edit-event.component';
import { DetailsEventComponent } from './pages/details-event/details-event.component';

export const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: 'add', component: AddEventComponent },
  { path: ':id/edit', component: EditEventComponent },
  { path: ':id/details', component: DetailsEventComponent },
];
