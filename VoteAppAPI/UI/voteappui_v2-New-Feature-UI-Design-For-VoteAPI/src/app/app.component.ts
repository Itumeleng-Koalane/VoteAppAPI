import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { NavbarComponent } from "./pages/navbar/navbar.component";
import { LandingScreenComponent } from "./pages/landing-screen/landing-screen.component";
import { LoginScreenComponent } from "./pages/login-screen/login-screen.component";
import { RegisterScreenComponent } from "./pages/register-screen/register-screen.component";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
  RouterOutlet,
  NavbarComponent,
  LandingScreenComponent,
  LoginScreenComponent,
  RegisterScreenComponent
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'VoteAppUi';
}
