import { Component, inject } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';

import { LoginMod } from '../models/loginModel';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-login',
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent {

  
  private _authService : AuthService = inject(AuthService);
  private _fb : FormBuilder = inject(FormBuilder);
  private _router : Router = inject(Router);

  private _user!: LoginMod;


   loginForm = this._fb.group({
      //nomControl : [valeur, [Validateurs synchrones], [Validateurs asynchrones] ]

      email : ['', [Validators.required, Validators.email]],

      password : ['', [Validators.required,Validators.minLength(8)]],

    });

  loginSubmit() {
  if(this.loginForm.invalid) {
    console.log('Invalid form', this.loginForm.value);
    return;
  }

  this._user = this.loginForm.value as LoginMod;

  this._authService.login(this._user).subscribe({
    next: (res) => {
      console.log('Réponse login:', res);
      alert(`Connexion réussie ! Bienvenue  ${res.lastName}`);
      this._router.navigate(['/']);
    },
    error: (error) => {
      console.log('Error', error);
    }
  });
}
}
