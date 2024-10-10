import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, ReactiveFormsModule, ValidatorFn, Validators } from '@angular/forms';
import { RouterLink, RouterModule } from '@angular/router';
import { FirstKeyPipe } from '../../../shared/pipes/first-key.pipe';
import { RegisterService } from '../../services/register.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { ViewEncapsulation } from '@angular/compiler';

@Component({
  selector: 'app-login-screen',
  standalone: true,
  imports: [
    ReactiveFormsModule,
    CommonModule,
    RouterLink,
    FirstKeyPipe,
    RouterModule
  ],
  templateUrl: './login-screen.component.html',
  styleUrl: './login-screen.component.css',
})

export class LoginScreenComponent {
form: FormGroup;
isSubmitted: boolean = false;

  constructor(public formBuilder: FormBuilder, private regService: RegisterService, private toastr: ToastrService, private router: Router){
    this.form = this.formBuilder.group({
      email : ['',[Validators.required,Validators.email]],
      password : ['',[Validators.required,
        Validators.minLength(6),
        Validators.pattern(/(?=.*[^a-zA-Z0-9 ])/)]]
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

  onLogin(){
    this.isSubmitted = true;
    if(this.form.valid)
    {
      this.regService.loginUser(this.form.value).subscribe({
        next:(res:any)=>{
          
          if(res.succeeded)
          {
            localStorage.setItem('token', res.token);
            this.router.navigateByUrl('pages/landing-screen');
            this.form.reset();
            this.isSubmitted = true;
            this.toastr.success('User Registration Successful','User registered!');
          }
          else
          {
            console.log('response', res);
          }
        },
        error:err=>
          {
          if(err.status == 400)
          {
            this.toastr.error('Email or Password is incorrect!!','Login Failed');
            this.form.reset();
          }
          else
          {
            this.toastr.error('Something went wrong!!','Please try again');
            this.form.reset();
          }
        }
      })
    }
  }
}