import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { environment } from '../../../../environments/environment.development';
import { Usuario } from '../../../modelos/Usuario';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  API_URI = environment.apiUrl;
  form: FormGroup;

  usuario: Usuario = {
    noCuenta: '',
    nip: ''
  };

  ngOnInit(): void {
    localStorage.removeItem('NoCuenta');
  }

  constructor(private http: HttpClient,
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private fb: FormBuilder,
    private toastr: ToastrService) {
    this.form = this.fb.group({
      nip: ['', Validators.required],
      noCuenta: ['', Validators.required],
      //nip: ['', [Validators.min(1000), Validators.max(99999)]],
      //noCuenta: ['', [Validators.min(1000), Validators.max(99999)]]
    });
  }

  login() {
    this.http.get(this.API_URI + '/Usuario/' + this.usuario.noCuenta + '/' + this.usuario.nip).subscribe(
      (res: any) => {
        console.log(res); //Muestra en consola
        this.router.navigate(['detalles']);
        this.usuario = res as Usuario; //Muestra en el navegador
        localStorage.setItem('NoCuenta', res.noCuenta);
        localStorage.setItem('Nip', res.nip);
      },
      (err) => {
        this.router.navigate(['login'])
        this.toastr.warning(
          'No se encontro al usuario',
          'Usuario no encontrado'
        );
      }
    );
  }
}
