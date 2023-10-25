import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { environment } from '../../../../environments/environment.development';
import { UsuarioCajero } from '../../../modelos/UsuarioCajero';


@Component({
  selector: 'app-movimientos',
  templateUrl: './movimientos.component.html',
  styleUrls: ['./movimientos.component.css']
})
export class MovimientosComponent implements OnInit {
  API_URI = environment.apiUrl;
  deposito: boolean = false;

 usuarioCajero: UsuarioCajero = {
    idUsuarioCajero: 0,
    usuario: {
      noCuenta: 0,
      nip: 0,
      nombre: '',
      apellidoPaterno: '',
      apellidoMaterno: '',
      saldo: 0
    },
    cajero: {
      idCajero: 0,
      saldo: 0
    },
    cantidadRetiro: 0,
    cantidadDeposito: 0
  }
  constructor(
    private http: HttpClient,
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private toastr: ToastrService
  ) {

  }

  ngOnInit(): void {
    
  }
  Add() {
    this.http.post(this.API_URI + '/UsuarioCajero', this.usuarioCajero).subscribe(
      (res) => {
        console.log(res);

        console.log('Se realizo correctamente el movimiento');
        this.router.navigate(['detalles']);

      },
      (err) => console.error(err)
    );
  }
}
