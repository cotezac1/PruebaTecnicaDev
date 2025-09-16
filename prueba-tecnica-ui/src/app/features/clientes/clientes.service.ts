import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Cliente } from '../../models/cliente.model';

@Injectable({
  providedIn: 'root'
})
export class ClientesService {

  private apiUrl = 'https://localhost:7203/api/clientes';

  constructor(private http: HttpClient) { }

  getClientesLinq(page: number = 1, size: number = 10): Observable<any> {
    return this.http.get(`${this.apiUrl}/linq?pageNumber=${page}&pageSize=${size}`);
  }

  getClientesSp(page: number = 1, size: number = 10): Observable<any> {
    return this.http.get(`${this.apiUrl}/sp?pageNumber=${page}&pageSize=${size}`);
  }
}