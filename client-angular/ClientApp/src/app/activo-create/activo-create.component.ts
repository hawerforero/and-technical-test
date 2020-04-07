import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { Component } from '@angular/core';
import { TipoActivo } from '../_interfaces/tipoactivo';
import { ActivosService } from '../shared/services/activos.service';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrService } from 'ngx-toastr';
import { RepositoryService } from '../shared/services/repository.service';
import { HttpClient } from '@angular/common/http';
import { Activo } from '../_interfaces/activo';

@Component({
  selector: 'app-activo-create',
  templateUrl: './activo-create.component.html'
})
export class ActivoCreateComponent {
  title = 'activo';
  tipos: TipoActivo[];
  activoModel = new Activo('3', 'Tablet', 'Tablet acer', '', '', '', '', '1');
  tipoHasError = true;
  submitted = false;
  errorMsg = '';

  constructor(private _activosService: ActivosService, private toastr: ToastrService, private repository: RepositoryService, private http: HttpClient) { }

  validateTipo(value) {
    if (value === 'default') {
      this.tipoHasError = true;
    } else {
      this.tipoHasError = false;
    }
  }

  onSubmit() {

    this.submitted = true;
    this._activosService.create(this.activoModel)
      .subscribe(
        response => {
              this.toastr.success("Activo creado.");
              window.location.href = "/activo-list";
            },
        error => {
          this.toastr.error("Error en base de datos");
          this.errorMsg = "No es posible inertar el activo";
        }
      )
  }

  //Lista de tipos
  ngOnInit() {
    this.http.get<TipoActivo[]>('https://localhost:44379/api/tipoactivos').subscribe(result => {
      this.tipos = result;
    }, error => console.error(error));   
  }

}
