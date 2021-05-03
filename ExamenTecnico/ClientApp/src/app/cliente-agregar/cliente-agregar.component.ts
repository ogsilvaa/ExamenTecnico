import { Component, OnInit, Inject } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import axios from "axios";

@Component({
  selector: 'app-cliente-agregar',
  templateUrl: './cliente-agregar.component.html',
  styleUrls: ['./cliente-agregar.component.css']
})
export class ClienteAgregarComponent implements OnInit {

  checkoutForm = this.formBuilder.group({
    Nombres: '',
    Apellidos: '',
    Correo: '',
    FechaNacimiento: '',
    Direccion: ''
  });
  constructor(private formBuilder: FormBuilder,
    private router: Router,
    @Inject('BASE_URL') private baseUrl: string) { }

  async onSubmit(): Promise<void> {
    console.log(this.checkoutForm.value);
    try {
      let respuesta = axios.post(this.baseUrl + "cliente", this.checkoutForm.value);
      //this.router.navigate(['/cliente-listar']);
    } catch (e) {
      console.log(e.response);
    }


    ;
  }
  ngOnInit() {
  }

}
