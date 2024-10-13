import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { UserComponent } from './pages/user/user.component';
import { LoginScreenComponent } from './pages/user/login-screen/login-screen.component';
import { RegisterScreenComponent } from './pages/user/register-screen/register-screen.component';
import { LandingScreenComponent } from './pages/landing-screen/landing-screen.component';
import { ProvincialSelectionScreenComponent } from './pages/provincial-selection-screen/provincial-selection-screen.component';
import { NavbarComponent } from './pages/navbar/navbar.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
  RouterOutlet,
  LandingScreenComponent,
  ProvincialSelectionScreenComponent,
  NavbarComponent
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'VoteAppUi';
}
