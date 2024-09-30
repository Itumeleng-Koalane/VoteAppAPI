import { Component } from '@angular/core';
import { RegisterScreenComponent } from './register-screen/register-screen.component';
import { LoginScreenComponent } from './login-screen/login-screen.component';

@Component({
  selector: 'app-user',
  standalone: true,
  imports: [
    RegisterScreenComponent,
    LoginScreenComponent
  ],
  templateUrl: './user.component.html',
  styleUrl: './user.component.css'
})
export class UserComponent {

}
