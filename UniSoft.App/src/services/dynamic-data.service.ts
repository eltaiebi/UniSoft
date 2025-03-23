// application.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Application, DynamicData } from '../models/application.model';

@Injectable({
  providedIn: 'root'
})
export class DynamicDataService {
  private apiUrl = 'http://localhost:5021/api/DynamicData';

  constructor(private http: HttpClient) { }

  getAllData(tableId: number): Observable<DynamicData> {
    return this.http.get<DynamicData>(`${this.apiUrl}/Data/${tableId}`);
  }
}