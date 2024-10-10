import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, ReactiveFormsModule, ValidatorFn, Validators } from '@angular/forms'; 
import { FirstKeyPipe } from '../../../shared/pipes/first-key.pipe';
import { RegisterService } from '../../services/register.service';
import { ToastrService } from 'ngx-toastr';
import { Router, RouterLink } from '@angular/router';

@Component({
  selector: 'app-register-screen',
  standalone: true,
  imports: [
    ReactiveFormsModule,
    CommonModule,
    FirstKeyPipe,
    RouterLink
  ],
  templateUrl: './register-screen.component.html',
  styleUrl: './register-screen.component.css'
})

export class RegisterScreenComponent {
  form:FormGroup;
  isSubmitted: boolean = false;

  constructor(public formBuilder: FormBuilder, private regService: RegisterService, private toastr: ToastrService,private route: Router){

    this.form = this.formBuilder.group({
      name : ['',Validators.required],
      surname : ['',[Validators.required]],
      email : ['',[Validators.required,Validators.email]],
      identificationNum : ['',[Validators.required,
                              Validators.maxLength(13),
                              Validators.pattern(/^[0-9]{6}[0-9]{4}[01][89][0-9]$/)]],
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
    if(this.form.valid)
    {
      this.regService.registerUser(this.form.value).subscribe({
        next:(res:any)=>{
          if(res.succeeded)
          {
            this.form.reset();
            this.route.navigateByUrl('pages/user/login-screen');
            this.isSubmitted = true;
            this.toastr.success('User Registration Successful','User registered!');
          }
          else
          {
            console.log('response',res);
          }
        },
        error:err=>
          {
            console.log('error',err);
        }
      });
    }
  }
}
