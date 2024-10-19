import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { Router, RouterLink, RouterModule } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-landing-screen',
  standalone: true,
  imports: [
    RouterLink,
    RouterModule,
    CommonModule
  ],
  templateUrl: './landing-screen.component.html',
  styleUrl: './landing-screen.component.css'
})
export class LandingScreenComponent {

  constructor(private router: Router,private toastr: ToastrService){}

  onLogout(){
    localStorage.removeItem('token');
    this.toastr.success('Logout succesful!');
    this.router.navigateByUrl('pages/user/login-screen');
  }
}
