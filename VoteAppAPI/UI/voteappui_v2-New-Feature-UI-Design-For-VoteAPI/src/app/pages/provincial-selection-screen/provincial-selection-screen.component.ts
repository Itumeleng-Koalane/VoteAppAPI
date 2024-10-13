import { Component } from '@angular/core';
import { RouterLink, RouterModule, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-provincial-selection-screen',
  standalone: true,
  imports: [
    RouterOutlet,
    RouterLink,
    RouterModule
  ],
  templateUrl: './provincial-selection-screen.component.html',
  styleUrl: './provincial-selection-screen.component.css'
})
export class ProvincialSelectionScreenComponent {

}
