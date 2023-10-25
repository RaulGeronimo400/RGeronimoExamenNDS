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
    noCuenta: 0,
    nip: 0,
    nombre: '',
    apellidoPaterno: '',
    apellidoMaterno: '',
    saldo: 0
  };

  loginAuth: boolean = false;

  constructor(private http: HttpClient,
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private fb: FormBuilder,
    private toastr: ToastrService) {
    this.form = this.fb.group({
      nip: ['', [Validators.min(1000), Validators.max(99999)]],
      noCuenta: ['', [Validators.min(1000), Validators.max(99999)]]
    });
  }

  ngOnInit(): void {
    const params = this.activatedRoute.snapshot.params;
    if (this.loginAuth) {
      
    }
  }

  login() {
    this.http.post(this.API_URI + '/Usuario', this.usuario).subscribe(
      (res) => {
        console.log(res); //Muestra en consola
        this.router.navigate(['detalles']);
        this.usuario = res as Usuario; //Muestra en el navegador

        this.loginAuth = true;
      },
      (err) => console.error(err)
    );
  }

  /* saveData() {
    sessionStorage.setItem('NoCuenta', this.usuario.NoCuenta);
} */
}
