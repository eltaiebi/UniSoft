// application.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Application } from '../models/application.model';

@Injectable({
  providedIn: 'root'
})
export class ApplicationService {
  private apiUrl = 'http://localhost:5021/api';

  constructor(private http: HttpClient) { }

  getApplicationDetails(id: number): Observable<Application> {
    return this.http.get<Application>(`${this.apiUrl}/Application/Details/${id}`);
  }
}