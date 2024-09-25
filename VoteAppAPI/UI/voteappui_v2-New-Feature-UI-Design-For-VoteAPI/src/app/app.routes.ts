import { Routes } from '@angular/router';
import { LoginScreenComponent } from './pages/login-screen/login-screen.component';
import { RegisterScreenComponent } from './pages/register-screen/register-screen.component';
import { NavbarComponent } from './pages/navbar/navbar.component';

export const routes: Routes = [
  {
    path: 'pages/landing-screen',
    component: LoginScreenComponent,
  },
  {
    path: 'pages/login-screen',
    component: LoginScreenComponent,
  },
  {
    path: 'pages/register-screen',
    component: RegisterScreenComponent,
  },
  {
    path: 'pages/navbar',
    component: NavbarComponent
  }
];
