import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { DynamicData, DynamicLine } from '../models/application.model';

@Injectable({
  providedIn: 'root'
})
export class DynamicDataService {
  private apiUrl = 'http://localhost:5021/api/DynamicData';

  constructor(private http: HttpClient) { }

  // Récupérer toutes les données d'une table
  getAllData(tableId: number): Observable<DynamicData> {
    return this.http.get<DynamicData>(`${this.apiUrl}/Data/${tableId}`);
  }

  // Ajouter une nouvelle ligne
  addData(tableId: number, newData: DynamicLine): Observable<string> {
    return this.http.post<string>(`${this.apiUrl}/Data/${tableId}`, newData);
  }

  // Modifier une ligne existante
  updateData(tableId: number, id: number, updatedData: DynamicLine): Observable<string> {
    return this.http.put<string>(`${this.apiUrl}/Data/${tableId}/${id}`, updatedData);
  }

  // Supprimer une ligne
  deleteData(tableId: number, id: number): Observable<string> {
    return this.http.delete<string>(`${this.apiUrl}/Data/${tableId}/${id}`);
  }

}
