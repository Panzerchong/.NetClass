import { Component } from '@angular/core';
import { LoginModel } from '../../shared/models/LoginModel';
import { Account } from '../../core/services/account';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: false,
  templateUrl: './login.html',
  styleUrl: './login.css'
})
export class Login {
  constructor(private accountService:Account,private router:Router){}



  loginModel:LoginModel={
    email:'',
    password:''
  };

  invalidLogin:boolean=false;

  onSubmit(){
    console.log("user click submit");
    console.log(this.loginModel);

    this.accountService.login(this.loginModel).subscribe(
      response=>{
        console.log("sent user to API")
        if(response==true){
          this.router.navigateByUrl("/");//http://localhost:4200
        }
        else{
          this.invalidLogin=true;
          
        }
      }
    )
  }
}
