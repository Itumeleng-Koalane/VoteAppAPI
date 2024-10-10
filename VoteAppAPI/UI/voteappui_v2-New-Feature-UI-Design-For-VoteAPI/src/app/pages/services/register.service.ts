import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class RegisterService {
  baseURL = 'https://localhost:7035/api';

  constructor(private http: HttpClient) { }

  registerUser(formData: any){
    return this.http.post(this.baseURL + '/signup', formData, {
      headers: new HttpHeaders({'Content-Type': 'application/json'})
    });    
  }

  loginUser(formData: any){
    return this.http.post(this.baseURL + '/signin', formData, {
      headers: new HttpHeaders({'Content-Type': 'application/json'})
    });    
  }
}
