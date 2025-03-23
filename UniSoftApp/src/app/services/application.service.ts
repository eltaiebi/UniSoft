import { Injectable } from '@angular/core';
import { ApplicationDto } from '../models/application-dto';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';

@Injectable({
  providedIn: 'root'
})
export class ApplicationService {

  private apiUrl = 'http://localhost:5021/api/Application'; // Remplacez par l'URL de votre API

  constructor(private http: HttpClient) { }

  // Exemple : Récupérer les détails d'une application par son ID
  getApplicationDetails(id: number): Observable<ApplicationDto> {
    return this.http.get<ApplicationDto>(`${this.apiUrl}/Details/${id}`);
  }
}
