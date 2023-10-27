import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Usuario } from '../../../modelos/Usuario';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';
import { environment } from '../../../../environments/environment';

@Component({
  selector: 'app-detalles',
  templateUrl: './detalles.component.html',
  styleUrls: ['./detalles.component.css']
})
export class DetallesComponent implements OnInit {
  Detalles: any = [];
  API_URI = environment.apiUrl;
  activatedRoute: any;

  usuario: Usuario = {
    noCuenta: '',
    nip: '',
    nombre: '',
    apellidoPaterno: '',
    apellidoMaterno: '',
    saldo: 0
  };

  tabla: boolean = false;

  constructor(private http: HttpClient, private router: Router) { }

  ngOnInit(): void {
    if (localStorage.getItem('NoCuenta') == null) {
      this.router.navigate(['login']);
    } else {
      this.GetUsuario();
      this.GetMovimientos();
    }
  }

  GetUsuario() {
    let value = localStorage.getItem('NoCuenta');
    this.http.get(this.API_URI + '/Usuario/' + value).subscribe(
      (res) => {
        console.log(res);
        this.usuario = res as Usuario;
      },
      (err) => console.error(err)
    );
  }

  GetMovimientos() {
    let value = localStorage.getItem('NoCuenta');
    this.http.get(this.API_URI + '/UsuarioCajero/' + value).subscribe(
      (res) => {
        console.log(res);
        this.Detalles = res;
      },
      (err) => console.error(err)
    );
  }

  Salir() {
    Swal.fire({
      title: '¿Estas seguro de salir de la aplicación?',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: '¡Salir!',
      cancelButtonText: 'Cancelar',
    }).then((result) => {
      if (result.isConfirmed) {
        localStorage.removeItem('NoCuenta');
        this.router.navigate(['login']);
      }
    });
  }
}

