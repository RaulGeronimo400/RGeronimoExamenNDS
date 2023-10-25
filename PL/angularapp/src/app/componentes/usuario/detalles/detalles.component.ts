import { Component, OnInit } from '@angular/core';
import { environment } from '../../../../environments/environment.development';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-detalles',
  templateUrl: './detalles.component.html',
  styleUrls: ['./detalles.component.css']
})
export class DetallesComponent {
  Detalles: any = [];
  API_URI = environment.apiUrl;
  activatedRoute: any;

  constructor(private http: HttpClient) { }

  OnInit(): void {
  }

  GetUsuario() {

  }
}
