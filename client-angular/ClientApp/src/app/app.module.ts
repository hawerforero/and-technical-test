import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';

import { EnvironmentUrlService } from './shared/services/environment-url.service';
import { RepositoryService } from './shared/services/repository.service';
import { ActivoListComponent } from './activo-list/activo-list.component';
import { ActivoDetailsComponent } from './activo-details/activo-details.component';
import { ActivoCreateComponent } from './activo-create/activo-create.component';
import { ActivoEditComponent } from './activo-edit/activo-edit.component';

import { MovimientoListComponent } from './movimientos/movimiento-list/movimiento-list.component';

import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MovimientoCreateComponent } from './movimientos/movimiento-create/movimiento-create.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    ActivoListComponent,
    ActivoDetailsComponent,
    ActivoCreateComponent,
    ActivoEditComponent,
    MovimientoListComponent,
    MovimientoCreateComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'activo-list', component: ActivoListComponent },
      { path: 'activo-details/:id', component: ActivoDetailsComponent },
      { path: 'activo-create', component: ActivoCreateComponent },
      { path: 'activo-edit/:id', component: ActivoEditComponent },
      { path: 'movimiento-list', component: MovimientoListComponent },
      { path: 'movimiento-create', component: MovimientoCreateComponent }
    ])
  ],
  providers: [
    EnvironmentUrlService,
    RepositoryService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
