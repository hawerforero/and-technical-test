import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { throwError } from 'rxjs';
import { ErrorHandlerService } from './error-handler.service';
import { Movimiento } from '../../_interfaces/movimiento';

@Injectable({
  providedIn: 'root'
})
export class MovimientosService {

 

  _url = 'https://localhost:44379/api/movimientos';
  constructor(private _http: HttpClient) { }

  create(movimiento: Movimiento) {
    return this._http.post<any>(this._url, movimiento)
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
