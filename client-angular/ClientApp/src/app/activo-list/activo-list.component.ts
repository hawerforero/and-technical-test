import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivosService } from '../shared/services/activos.service';

@Component({
    selector: 'app-activo-list',
    templateUrl: './activo-list.component.html'
})
/** activo-list component*/
export class ActivoListComponent {
    /** activo-list ctor */
  public activos: Activo[];
  errorMsg = '';

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, private _activosService: ActivosService) {
    http.get<Activo[]>('https://localhost:44379/api/activos').subscribe(result => {
      this.activos = result;
    }, error => console.error(error));
  }

  public deleteActivo(id:string) {

    console.log(id);
    this._activosService.delete(id)
      .subscribe(
        response => {
          window.location.href = "/activo-list";
        },
        error => {
          this.errorMsg = "No es posible elimnar el activo";
        }
      )

  }
}

interface Activo {
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
    sigla: string;
  };
}
