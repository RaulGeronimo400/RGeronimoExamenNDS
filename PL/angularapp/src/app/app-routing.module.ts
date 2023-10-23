import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

//Importamos el archivo que viene en la ruta sig.
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './componentes/usuario/login/login.component';


const routes: Routes = [
  //CREACION DE OBJETOS
  //Índice
  {
    path: '',
    redirectTo: '/login',
    pathMatch: 'full'
  },
  //Login
  {
    path: 'login',
    component: LoginComponent
  },

  //404
  {
    path: '**',
    redirectTo: '/login',
    pathMatch: 'full'
  }
];

@NgModule({
  declarations: [],
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
