import { Component } from '@angular/core';
import { MenubarModule } from 'primeng/menubar';
import { MenuItem } from 'primeng/api';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-nav',
  standalone: true,
  imports: [MenubarModule, CommonModule],
  templateUrl: './nav.component.html',
  styleUrl: './nav.component.scss',
})
export class NavComponent {
  items: MenuItem[] | undefined;

  ngOnInit() {
    this.items = [
      {
        label: 'Home',
        icon: 'pi pi-home',
        route: '/home',
      },
      {
        label: 'Featured',
        icon: 'pi pi-star',
        route: '/featured',
      },
      {
        label: 'Contacts',
        icon: 'pi pi-star',
        route: '/contacts',
      },
    ];
  }
}
