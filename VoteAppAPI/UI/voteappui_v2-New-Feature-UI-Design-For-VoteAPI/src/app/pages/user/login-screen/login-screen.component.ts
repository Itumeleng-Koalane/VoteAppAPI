import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';

@Component({
  selector: 'app-login-screen',
  standalone: true,
  imports: [
    ReactiveFormsModule
  ],
  templateUrl: './login-screen.component.html',
  styleUrl: './login-screen.component.css'
})

export class LoginScreenComponent {
form: FormGroup;
  constructor(public formBuilder: FormBuilder){
    this.form = this.formBuilder.group({
      email : ['',[Validators.required,Validators.email]],
      password : ['',Validators.required]
  })
}

  onLogin(){
    console.log(this.form.value);
  }
}