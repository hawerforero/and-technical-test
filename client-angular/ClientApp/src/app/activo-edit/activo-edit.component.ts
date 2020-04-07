import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FormBuilder } from '@angular/forms';
import { FormGroup, FormControl, FormArray, Validators } from '@angular/forms';
import { TipoActivo } from '../_interfaces/tipoactivo';
import { ActivosService } from '../shared/services/activos.service';

@Component({
    selector: 'app-activo-edit',
    templateUrl: './activo-edit.component.html'
})
/** activo-edit component*/
export class ActivoEditComponent implements OnInit{
/** activo-edit ctor */

  tipos: TipoActivo[];
  private activo: Activo;
  public errorMessage: string = '';
  errorMsg = '';

  //editForm: FormGroup;
  editForm = new FormGroup({
    nombre: new FormControl(),
    descripcion: new FormControl(),
    serial: new FormControl(),
    valor: new FormControl(),
    fecha: new FormControl(),
    tipoactivoid: new FormControl()
  })


  constructor(private _activosService: ActivosService, private http: HttpClient, private activeRoute: ActivatedRoute, private fb: FormBuilder) {

    
  }

  ngOnInit() {

    this.http.get<TipoActivo[]>('https://localhost:44379/api/tipoactivos').subscribe(result => {
      this.tipos = result;
    }, error => console.error(error));   

    this.http.get<Activo>('https://localhost:44379/api/activos/' + this.activeRoute.snapshot.params['id']).subscribe(result => {
      this.activo = result;
      this.editForm = this.fb.group({
        id: [this.activo.id, [Validators.required]],
        nombre: [this.activo.nombre, [Validators.required]],
        descripcion: [this.activo.descripcion, [Validators.required]],
        serial: [this.activo.serial, [Validators.required]],
        valor: [this.activo.valor, [Validators.required]],
        fecha: [this.activo.fecha, [Validators.required]],
        estado: [this.activo.estado],
        tipoactivoid: [this.activo.tipoActivo.id, [Validators.required]]
      });
    }, error => console.error(error));
  }

  onSubmit() {
    console.log(this.editForm.value);
    this._activosService.edit(this.editForm.value)
      .subscribe(
        response => {
          window.location.href = "/activo-list";
        },
        error => {
          this.errorMsg = "No es posible actualizar el activo";
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
    sigla: string
  }
}
