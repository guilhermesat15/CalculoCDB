import { Injectable, ChangeDetectorRef, Inject } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { CalculadorCDB } from '../model/calculadorCDB';
import { catchError, map, Observable, throwError } from 'rxjs';
import { ResultadoCalculadorCDB } from '../model/resultadoCalculoCDB';
import { environment } from '../../environments/environment.development';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
    'accept': '*/*'
  })
}

@Injectable({
  providedIn: 'root'
})
export class CalculadorCDBService {

  private apiUrl = environment.apiUrl;
  
  constructor(private http: HttpClient) {  }
  
  public calcularCDB(calculadorCDB: CalculadorCDB):Observable<any> {    

    return this.http.post<any>(this.apiUrl + '/calculador/calcular-cdb', calculadorCDB, httpOptions);   
    
  }
    
}
