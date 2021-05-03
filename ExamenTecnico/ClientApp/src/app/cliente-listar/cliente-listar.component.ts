import { Component, OnInit, Inject } from '@angular/core';
import axios from "axios"

@Component({
  selector: 'app-cliente-listar',
  templateUrl: './cliente-listar.component.html',
  styleUrls: ['./cliente-listar.component.css']
})
export class ClienteListarComponent implements OnInit {
  clientes: any;
  constructor(@Inject("BASE_URL") private baseUrl: string) {
  console.log("constructor");
    
  }

  ngOnInit(): void {
  console.log("inicio");
    axios(this.baseUrl + "cliente")
      .then(x => { this.clientes = x.data; console.log(x.data) })
      .catch(x => console.log(x));
  }

}
