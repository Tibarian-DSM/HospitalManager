import { Component, inject } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { AuthService } from '../services/auth.service';
import { Router } from '@angular/router';
import { registerMod } from '../models/registerModel';
import { first } from 'rxjs';
import { validateHeaderName } from 'http';
import { error } from 'console';
import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-register',
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.scss'
})
export class RegisterComponent {

  private _authService : AuthService= inject(AuthService)
  private _fb : FormBuilder = inject(FormBuilder)
  private _router:Router = inject(Router)

  private _user!: registerMod;

  registerForm = this._fb.group(
    {
      firstname : ['',[Validators.required, Validators.maxLength(100)]],
      lastname : ['',[Validators.required ,Validators.maxLength(100)]],
      email: ['',[Validators.required,Validators.email]],
      password: ['', [Validators.required,Validators.pattern(/^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[#?!@$%^&*-]).{8,}$/)]]
    }
  )

  registerSubmit(){

    if(this.registerForm.invalid)
    {
      this.registerForm.markAllAsTouched();
      return ; 
    }
    this._user = this.registerForm.value as registerMod

    this._authService.register(this._user).subscribe(
      {
        next:() =>
          {
            alert('Inscription réussi!')
            this._router.navigate(['/login'])
          }, 
        error:(error) =>
        {
          console.log('Error',error)
        }
      });
  }
  
}
