import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Bebida } from './Bebida';

const httOptions = {
    headers: new HttpHeaders({
        'Content-Type' : 'application/json'
    })
}

@Injectable({
    provideIn: 'root'
})

export class BebidasService {

  apiUrl = 'http://localhost:5000/Bebida';

  constructor(private http: HttpClient) { }

  cadastrarBebida(bebida: Bebida): Observable<any> {
      const url = `${this.apiUrl}/cadastroBebida`;

      return this.http.post<Bebida>(url, bebida, httOptions);
  }

  listarBebidas(): Observable<Bebida[]> {
      const url = `${this.apiUrl}/MostrarBebidas`;

      return this.http.get<Bebida[]>(url);
  }

  buscarBebida(id: number): Observable<Bebida> {
      const url = `${this.apiUrl}/BuscarBebida/${id}`;

      return  this.http.get<Bebida>(url);
  }

  alterarBebida(bebida: Bebida): Observable<any> {
      const url = `${this.apiUrl}/AlterarBebida`;

      return this.http.put<Bebida>(url, bebida, httOptions);
  }
}