import { IfStmt } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { BackendService } from 'src/app/backend.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  currentUser : Object = {};
  name: String = null;
  clientid: String = null;
  bdate: String = null;
  address: String = null;
  phone1: String = null;
  phone2: String = null;
  email: String = null;
  username: String = null;
  password: String = null;
  points: String = null;

  isError: Boolean;
  textError: String;
  isSuccess: Boolean = false;

  tempEvent: any;

  constructor(private backend: BackendService) { }

  ngOnInit() {
  }

  handleRegister() {
    

    let data = [this.name, this.clientid, this.bdate, this.address, this.phone1, this.phone2, this.email, this.username, this.password, this.points]

    console.log(data)
    if(true){
    this.tempEvent['cliente_nombre'] = this.name,
    this.tempEvent['cedula'] = this.clientid,
    this.tempEvent['fecha_nac'] = this.bdate,
    this.tempEvent['direccion'] = this.address,
    this.tempEvent['telefono1'] = this.phone1,
    this.tempEvent['telefono2'] = this.phone2,
    this.tempEvent['email'] = this.email,
    this.tempEvent['usuario'] = this.username,
    this.tempEvent['psw_cliente'] = this.password,
    this.tempEvent['puntos'] = 0

    this.backend.postClient(this.tempEvent).subscribe(res=>console.log('Agragado correctamente'))
    }
    
    }

}
