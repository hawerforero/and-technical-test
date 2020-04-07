import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { throwError } from 'rxjs';
import { ErrorHandlerService } from './error-handler.service';
import { Activo } from '../../_interfaces/activo';

@Injectable({
  providedIn: 'root'
})
export class ActivosService {

 

  _url = 'https://localhost:44379/api/activos';
  constructor(private _http: HttpClient) { }

  create(activo: Activo) {
    return this._http.post<any>(this._url, activo)
      .pipe(catchError(this.errorHandler))
  }

  edit(activo: IActivo) {
    return this._http.put<any>(this._url + '/' + activo.id, activo)
      .pipe(catchError(this.errorHandler))
  }

  delete(id: string) {
    return this._http.delete<any>(this._url + '/' + id)
      .pipe(catchError(this.errorHandler))
  }

  errorHandler(error: HttpErrorResponse) {
    return throwError(error)
  }

}


interface IActivo {
  id: string;
  nombre: string;
  descripcion: string;
  serial: string;
  valor: string;
  fecha: string;
  estado: string;
  tipoActivo: {
    id: string;
    nombre: string;
    sigla: string
  }
}
