import { Component } from '@angular/core';
import { RegisterScreenComponent } from './register-screen/register-screen.component';
import { LoginScreenComponent } from './login-screen/login-screen.component';
import { ChildrenOutletContexts, RouterOutlet } from '@angular/router';
import { animate, query, style, transition, trigger } from '@angular/animations';

@Component({
  selector: 'app-user',
  standalone: true,
  imports: [
    RegisterScreenComponent,
    RouterOutlet
  ],
  templateUrl: './user.component.html',
  styleUrl: './user.component.css',
  animations: [
    trigger('routerFadeIn',[
      transition('* <=> *',[
        query('center',[
          style({ opacity: 0 }),
          animate('1s ease-in-out',style({ opacity : 1})),
        ],{ optional: true}),
      ])
    ])
  ]
})
export class UserComponent {

  constructor(private context: ChildrenOutletContexts){}

  getRouterUrl(){
    return this.context.getContext('primary')?.route?.url;
  }
}
