import { Component } from '@angular/core';

@Component({
  selector: 'app-return-btn',
  standalone: true,
  imports: [],
  templateUrl: './return-btn.component.html',
  styleUrl: './return-btn.component.scss',
})
export class ReturnBtnComponent {
  returnPage() {
    window.history.back();
  }
}
