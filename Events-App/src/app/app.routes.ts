import { Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { AddEventComponent } from './pages/add-event/add-event.component';
import { EditEventComponent } from './pages/edit-event/edit-event.component';
import { DetailsEventComponent } from './pages/details-event/details-event.component';
import { FeaturedComponent } from './pages/featured/featured.component';
import { ContactsComponent } from './pages/contacts/contacts.component';
import { ProfileComponent } from './pages/profile/profile.component';
import { LoginComponent } from './pages/login/login.component';
import { RegisterComponent } from './pages/register/register.component';

export const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: 'add', component: AddEventComponent },
  { path: 'featured', component: FeaturedComponent },
  { path: 'contacts', component: ContactsComponent },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: ':id/profile', component: ProfileComponent },
  { path: ':id/edit', component: EditEventComponent },
  { path: ':id/details', component: DetailsEventComponent },
];
