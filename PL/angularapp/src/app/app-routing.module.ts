import { NgModule } from '@angular/core';

//Importamos el archivo que viene en la ruta sig.
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './componentes/usuario/login/login.component';
import { DetallesComponent } from './componentes/usuario/detalles/detalles.component';
import { MovimientosComponent } from './componentes/usuario/movimientos/movimientos.component';
import { RegistroComponent } from './componentes/usuario/registro/registro.component';


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
  {
    path: 'detalles',
    component: DetallesComponent
  },
  {
    path: 'movimientos',
    component: MovimientosComponent
  },
  //Registro
  {
    path: 'registro',
    component: RegistroComponent
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
