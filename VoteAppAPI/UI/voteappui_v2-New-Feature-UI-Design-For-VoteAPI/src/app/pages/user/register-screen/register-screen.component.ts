import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, ReactiveFormsModule, ValidatorFn, Validators } from '@angular/forms'; 

@Component({
  selector: 'app-register-screen',
  standalone: true,
  imports: [
    ReactiveFormsModule,
    CommonModule
  ],
  templateUrl: './register-screen.component.html',
  styleUrl: './register-screen.component.css'
})

export class RegisterScreenComponent {
  form:FormGroup;
  isSubmitted: boolean = false;

  constructor(public formBuilder: FormBuilder){

    this.form = this.formBuilder.group({
      name : ['',Validators.required],
      surname : ['',Validators.required],
      email : ['',[Validators.required,Validators.email]],
      identificationNum : ['',Validators.required],
      password : ['',[Validators.required,
                      Validators.minLength(6),
      Validators.pattern(/(?=.*[^a-zA-Z0-9 ])/)]],
      confirmPassword : ['',Validators.required],
    },{validators: this.passwordMatchValidation});
  }

  passwordMatchValidation: ValidatorFn = (control: AbstractControl):null => {
    const password = control.get('password');
    const confirmPassword = control.get('confirmPassword');

    if(password && confirmPassword && password.value != confirmPassword.value)
    {
      confirmPassword?.setErrors({passwordMismatch:true});
    }
    else
    {
      confirmPassword?.setErrors(null);
    }
      return null;
  }

  hasDisplayableError(controlName: string): Boolean
  {
    const control = this.form.get(controlName);

    return Boolean(control?.invalid) &&
    (this.isSubmitted || Boolean(control?.touched))
  }

  onSubmit(){
    this.isSubmitted = true;
    console.log(this.form.value);
  }
}
