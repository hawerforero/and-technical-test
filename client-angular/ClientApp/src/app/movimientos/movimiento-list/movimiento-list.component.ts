import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-movimiento-list',
  templateUrl: './movimiento-list.component.html'
})


export class MovimientoListComponent {
 
  public movimientos: Movimiento[];
  errorMsg = '';

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Movimiento[]>('https://localhost:44379/api/movimientos').subscribe(result => {
      this.movimientos = result;
    }, error => console.error(error));
  }

}

interface Movimiento {
  id: string;
  fecha: string;
  tipoMovimiento: {
    id: string;
    nombre: string;
    sigla: string;
  };
  activo: {
    id: string;
    nombre: string;
  };
  persona: {
    id: string;
    nombre: string;
  };
  area: {
    id: string;
    nombre: string;
  };
    observacion: string;
}
