import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';
import { BackendService } from 'src/app/backend.service';
import { StorageService } from 'src/app/storage.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit, OnDestroy {
  constructor(private localStorage: StorageService, private router: Router, private backend: BackendService) {}

  email: string = ''
  password: string = ''
  isError: boolean = false
  textError: String;

  ngOnInit() {
  }
  ngOnDestroy() {
  }

  handleLogin(){
    this.backend.getClient(this.email).subscribe(
      (data : Object) => {
        if (this.password !== data[0]['psw_cliente']){
          this.isError = true
          this.textError = 'Email or password incorrect!'
          return
        }
        
        this.localStorage.saveData('user', JSON.stringify(data[0]))
        this.router.navigate(['/calendar'])
        return
      }, (error => {
        if (error.status === 404) {
          this.isError = true
          this.textError = 'Email or password incorrect!'
        }
      })
    )  
    return
  }

}
