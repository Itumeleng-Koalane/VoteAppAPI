import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { UserComponent } from './pages/user/user.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
  RouterOutlet,
  UserComponent
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'VoteAppUi';
}
