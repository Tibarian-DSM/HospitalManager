
import { Injectable, PLATFORM_ID, inject, signal } from '@angular/core';
import { environnement } from '../../../environement/environement';
import { BehaviorSubject } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { registerMod } from '../models/registerModel';
import { API_CONST } from '../../core/api.constants';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  // Injection du token de la plateforme (navigateur, serveur, etc.)
  private platformId = inject(PLATFORM_ID);

  // URL de base de l'API récupérée depuis les environnements
  private _apiUrl = environnement.apiUrl;

  // Signal Angular pour stocker le token d'authentification (initialisé à null)
 // private _token = signal<string | null>(null);

  private _client = inject(HttpClient)

    register(value: registerMod) {
    return this._client.post<registerMod>(
      `${this._apiUrl}/${API_CONST.Auth.Register}`,
      value
    );
  }

  // Expose uniquement en lecture le token pour les composants qui l'utilisent
  // token = this._token.asReadonly();

  //   getToken():string |null {
    
  //   if (typeof sessionStorage !== 'undefined')
  //   {
  //     console.warn(sessionStorage);
  //     return sessionStorage.getItem('token');
  //   }
 
  //   return null;
  // }
}
