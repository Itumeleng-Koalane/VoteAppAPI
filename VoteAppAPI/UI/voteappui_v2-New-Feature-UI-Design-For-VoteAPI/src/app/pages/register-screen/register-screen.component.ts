import { Component, inject, NgModule, OnDestroy } from '@angular/core';
import { FormsModule } from '@angular/forms'; 
import { AddRegisterRequest } from '../models/add-register-request.model';
import { RegisterService } from '../services/register.service';
import { Subscription } from 'rxjs';
import { ToastrService } from 'ngx-toastr'

@Component({
  selector: 'app-register-screen',
  standalone: true,
  imports: [
    FormsModule,
  ],
  templateUrl: './register-screen.component.html',
  styleUrl: './register-screen.component.css'
})

export class RegisterScreenComponent implements OnDestroy {

  model : AddRegisterRequest;

  private addRegisterSubscription? : Subscription

  constructor(private registerService: RegisterService, private toastr:ToastrService){
    this.model = {
      email : '',
      password : '',
      //name : '',
      //surname : '',
    };
  }
  
  onFormRegister(): void{
    this.addRegisterSubscription = this.registerService.AddRegister(this.model).subscribe(
      res => {
        console.log('Saved to the DB Successfully!!');
        this.toastr.success('User Successfully Registered!!')
      },
        error => {
        console.log('Unable to saved details to the DB!!');
        this.toastr.error('Unable to register user details!!');
      }
    );
  }
  
  ngOnDestroy(): void {
    this.addRegisterSubscription?.unsubscribe();
  }
}
