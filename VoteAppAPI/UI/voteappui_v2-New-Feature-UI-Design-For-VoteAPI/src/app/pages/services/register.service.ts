import { Injectable } from '@angular/core';
import { AddRegisterRequest } from '../models/add-register-request.model';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class RegisterService {

  constructor(private http : HttpClient) { }

  AddRegister(model: AddRegisterRequest): Observable<any>{
    return this.http.post('https://localhost:7035/register', model, { headers: { 'Content-Type': 'application/json' } });
  }
}
