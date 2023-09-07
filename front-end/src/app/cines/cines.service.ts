import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { cineCreacionDTO, cineDTO } from './cine';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CinesService {
  
  constructor(private http: HttpClient) { }

  private apiURL = environment.apiURL + 'cines';

  public crear(cine: cineCreacionDTO){
    return this.http.post(this.apiURL, cine);
  }

  public obtenerTodos(pagina: number, cantidadRegistrosAMostrar: number) : Observable<any> {
    let params = new HttpParams();
    params = params.append('Pagina', pagina.toString());
    params = params.append('recordsPorPagina', cantidadRegistrosAMostrar.toString());
    return this.http.get<cineDTO[]>(this.apiURL, {observe: 'response', params});
  }

  public obtenerPorId(id: number): Observable<cineDTO>{
    return this.http.get<cineDTO>(`${this.apiURL}/${id}`);
  }

  public editar(id: Number, cine: cineCreacionDTO){
    return this.http.put(`${this.apiURL}/${id}`, cine);
  }
  
  public borrar(id: Number) {
    return this.http.delete(`${this.apiURL}/${id}`);
  }
}
