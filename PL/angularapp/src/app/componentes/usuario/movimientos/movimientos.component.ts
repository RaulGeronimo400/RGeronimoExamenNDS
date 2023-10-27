import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { UsuarioCajero } from '../../../modelos/UsuarioCajero';
import { environment } from '../../../../environments/environment';


@Component({
  selector: 'app-movimientos',
  templateUrl: './movimientos.component.html',
  styleUrls: ['./movimientos.component.css']
})
export class MovimientosComponent implements OnInit {
  API_URI = environment.apiUrl;
  deposito: boolean = false;
  form: FormGroup;

  usuarioCajero: UsuarioCajero = {
    idUsuarioCajero: 0,
    usuario: {
      noCuenta: '',
      nip: '',
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
    cantidadDeposito: 0,
    fecha: new Date
  }

  constructor(
    private http: HttpClient,
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private fb: FormBuilder,
    private toastr: ToastrService
  ) {
    this.form = this.fb.group({
      cantidadRetiro: ['', [Validators.min(0), Validators.max(99999)]],
      cantidadDeposito: ['', [Validators.min(0), Validators.max(99999)]]
    });
  }

  ngOnInit(): void {
    if (localStorage.getItem('NoCuenta') == null) {
      this.router.navigate(['login']);
    }
  }

  Add() {
    if (this.usuarioCajero.cantidadDeposito != 0 || this.usuarioCajero.cantidadRetiro != 0) {

      let value = localStorage.getItem('NoCuenta');
      this.usuarioCajero.usuario.noCuenta = value!;
      this.usuarioCajero.usuario.nip = "0";

      this.http.post(this.API_URI + '/UsuarioCajero', this.usuarioCajero).subscribe(
        (res) => {
          console.log(res);

          console.log('Se realizo correctamente el movimiento');
          this.toastr.success(
            'Se realizo correctamente el movimiento',
            'Movimiento correcto'
          );
          this.router.navigate(['detalles']);

        },
        (err) => {
          this.router.navigate(['detalles'])
          this.toastr.warning(
            'El usuario no tiene el saldo suficiente',
            'Saldo insuficiente'
          );
        }
      );
    } else {
      this.router.navigate(['detalles'])
      this.toastr.info(
        'El usuario no realizo ningun movimiento',
        'Movimiento cancelado'
      );
    }
  }
}
