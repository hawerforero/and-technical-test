import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { Component } from '@angular/core';
import { MovimientosService } from '../../shared/services/movimientos.service';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrService } from 'ngx-toastr';
import { RepositoryService } from '../../shared/services/repository.service';
import { HttpClient } from '@angular/common/http';
import { Movimiento } from '../../_interfaces/movimiento';
import { TipoMovimiento } from '../../_interfaces/tipomovimiento';
import { Activo } from '../../_interfaces/activo';
import { Persona } from '../../_interfaces/persona';
import { Area } from '../../_interfaces/area';

@Component({
  selector: 'app-movimiento-create',
  templateUrl: './movimiento-create.component.html'
})
export class MovimientoCreateComponent {
  title = 'movimiento';
  tipos: TipoMovimiento[];
  activos: Activo[];
  personas: Persona[];
  areas: Area[];

  movimientoModel = new Movimiento('1','','1','1','1','1','');
  tipoHasError = true;
  submitted = false;
  errorMsg = '';

  constructor(private _movimientosService: MovimientosService, private toastr: ToastrService, private repository: RepositoryService, private http: HttpClient) { }

  validateTipo(value) {
    if (value === 'default') {
      this.tipoHasError = true;
    } else {
      this.tipoHasError = false;
    }
  }

  onSubmit() {

    this.submitted = true;
    this._movimientosService.create(this.movimientoModel)
      .subscribe(
        response => {
          this.toastr.success("Movimiento creado.");
          window.location.href = "/movimiento-list";
        },
        error => {
          this.toastr.error("Error en base de datos");
          this.errorMsg = "No es posible inertar el movimiento, el activo ya se encuentra asignado";
        }
      )
  }

  //Lista de parametricas
  ngOnInit() {
    this.http.get<TipoMovimiento[]>('https://localhost:44379/api/tipomovimientos').subscribe(result => {
      this.tipos = result;
    }, error => console.error(error));

    this.http.get<Activo[]>('https://localhost:44379/api/activos').subscribe(result => {
      this.activos = result;
    }, error => console.error(error));

    this.http.get<Persona[]>('https://localhost:44379/api/personas').subscribe(result => {
      this.personas = result;
    }, error => console.error(error));

    this.http.get<Area[]>('https://localhost:44379/api/areas').subscribe(result => {
      this.areas = result;
    }, error => console.error(error));

  }

}
