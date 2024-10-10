import { Routes } from '@angular/router';
import { LoginScreenComponent } from './pages/user/login-screen/login-screen.component';
import { RegisterScreenComponent } from './pages/user/register-screen/register-screen.component';
import { UserComponent } from './pages/user/user.component';
import { LandingScreenComponent } from './pages/landing-screen/landing-screen.component';

export const routes: Routes = [
  { path: '', redirectTo: '/pages/user/login-screen', pathMatch: 'full' },
  {
    path: 'pages/user',component: UserComponent,
    children: [
      { path: 'register-screen', component: RegisterScreenComponent },
      { path: 'login-screen', component: LoginScreenComponent }, 
    ]
  },
];

