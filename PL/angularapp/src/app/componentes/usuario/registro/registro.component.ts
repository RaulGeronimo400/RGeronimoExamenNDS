import { Component } from '@angular/core';
import { Usuario } from '../../../modelos/Usuario';
import { environment } from '../../../../environments/environment.development';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-registro',
  templateUrl: './registro.component.html',
  styleUrls: ['./registro.component.css']
})
export class RegistroComponent {
  API_URI = environment.apiUrl;
  form: FormGroup;

  usuario: Usuario = {
    noCuenta: '',
    nip: '',
    nombre: '',
    apellidoPaterno: '',
    apellidoMaterno: '',
    saldo: 0
  };

  constructor(
    private http: HttpClient,
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private fb: FormBuilder,
    private toastr: ToastrService
  ) {
    this.form = this.fb.group({
      nip: ['', Validators.required],
      nombre: ['', Validators.required],
      apellidoPaterno: ['', Validators.required],
      apellidoMaterno: ['', Validators.required],
    });
  }

  Add() {
    this.usuario.noCuenta = "0";
    this.http.post(this.API_URI + '/Usuario', this.usuario).subscribe(
      (res: any) => {
        console.log(res);
        this.router.navigate(['login']);
        this.toastr.success(
          `El usuario '${this.usuario.nombre}'fue registrado correctamente`,
          `El numero de cuenta es: '${res}'`
        );
      },
      (err) => console.log(err)
    );
  }
}
