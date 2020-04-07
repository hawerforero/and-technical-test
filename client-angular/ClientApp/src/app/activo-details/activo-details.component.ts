import { Component, Inject } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { Activo } from '../_interfaces/activo';

@Component({
  selector: 'app-activo-details',
  templateUrl: './activo-details.component.html'
})
export class ActivoDetailsComponent {
  public activo: Activo;
  public errorMessage: string = '';

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, private activeRoute: ActivatedRoute) {
    http.get<Activo>('https://localhost:44379/api/activos/' + this.activeRoute.snapshot.params['id']).subscribe(result => {
      this.activo = result;
    }, error => console.error(error));
  }


}
