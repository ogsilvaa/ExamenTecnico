import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { ClienteAgregarComponent } from './cliente-agregar/cliente-agregar.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ClienteListarComponent } from './cliente-listar/cliente-listar.component';
@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    ClienteAgregarComponent,
    ClienteListarComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: ClienteListarComponent, pathMatch: 'full' },
    { path: 'counter', component: CounterComponent },
    { path: 'cliente-agregar', component: ClienteAgregarComponent },
      { path: 'cliente-listar', component: ClienteListarComponent },
], { relativeLinkResolution: 'legacy' }),
    BrowserAnimationsModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
