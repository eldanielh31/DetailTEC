import { Component, OnInit } from '@angular/core';
import { BackendService } from 'src/app/backend.service';
import { StorageService } from 'src/app/storage.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  isSuccess: Boolean = false

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

  constructor(private localStorage: StorageService, private backend: BackendService) { 
    this.currentUser = JSON.parse(this.localStorage.getData('user'));
    console.log(this.currentUser)
  }

  ngOnInit() {
    
  }

  //Funcion para cambiar datos del cliente
  handleUpdate(){

    let listData = ['cliente_nombre', 'cedula', 'fecha_nac', 'direccion','telefono1', 'telefono2', 'email', 'usuario', 'psw_cliente', 'puntos']
    let dataToUpdate = [this.name, this.clientid, this.bdate, this.address, this.phone1, this.phone2, this.email, this.username, this.password, this.points]

      let con = 0;
      dataToUpdate.forEach(element => {
        if (element !== null) {
          this.currentUser[listData[con]] = element
        }
        else if (element !== null && element !== '') {
          this.currentUser[listData[con]] = element
        }
        con++;
      });

      console.log(this.currentUser)
      this.backend.putClient(this.currentUser).subscribe(data => {
        console.log('Posteado correctamente')
      })
      
      this.localStorage.saveData('user', JSON.stringify(this.currentUser))
  
      this.isSuccess = true
  }
}


