
import { Injectable, PLATFORM_ID, inject, signal } from '@angular/core';
import { environnement } from '../../../environement/environement';
import { BehaviorSubject, map, Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { registerMod } from '../models/registerModel';
import { API_CONST } from '../../core/api.constants';
import { LoginMod } from '../models/loginModel';
import { currentUser } from '../models/currentUserModel';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  // Injection du token de la plateforme (navigateur, serveur, etc.)
  private platformId = inject(PLATFORM_ID);

  // URL de base de l'API récupérée depuis les environnements
  private _apiUrl = environnement.apiUrl;

  // Signal Angular pour stocker le token d'authentification (initialisé à null)
  private _token = signal<string | null>(null);

  private _currentUserSubject : BehaviorSubject<currentUser | null>;

    public get currentUser():currentUser|null {
    return this._currentUserSubject.value;
  }

constructor( private _client: HttpClient, private _route:Router) {

    let user:currentUser | null = null;
    // On vérifie que le code s'exécute bien dans un navigateur (évite erreur côté serveur)
    if(typeof sessionStorage !== 'undefined')
    {
      try{
        const userJson = sessionStorage.getItem('user');
        user= userJson ? JSON.parse(userJson) as currentUser:null;
      } catch(e)
      {
        console.error("Erreur parsing Json dans sessionStorage",e);
        sessionStorage.removeItem('user')
      }
    }
    
    this._currentUserSubject = new BehaviorSubject<currentUser|null>(user)
  }


  login (value :LoginMod ):Observable<currentUser>
  {// Les valeurs de retours placées dans le chevrons peuvent être multiple
    return this._client.post<{ 
                        token: string;
                        user:currentUser ;
                      }>(
      `${this._apiUrl}/${API_CONST.Auth.Login}`,
      value)
      .pipe (
        
        map(response =>
              {
                console.log("reponse du login reçue:");
                console.log(response)
                if (typeof sessionStorage !=='undefined')
                {
                  sessionStorage.setItem('token', response.token);
                  sessionStorage.setItem('user', JSON.stringify(response.user));
                }
                this._currentUserSubject.next(response.user)
                return response.user
              }),
        );
  
  }

  register(value: registerMod) {
    return this._client.post<registerMod>(
      `${this._apiUrl}/${API_CONST.Auth.Register}`,
      value
    );
  }


logout():void {

  if(typeof sessionStorage !=='undefined')
  {
    sessionStorage.removeItem('user');
    sessionStorage.removeItem('token');
	}

  this._currentUserSubject.next(null);
  this._route.navigate([`${API_CONST.Auth.Login}`])
}

  // Expose uniquement en lecture le token pour les composants qui l'utilisent
    token = this._token.asReadonly();

     getToken():string |null {
    
    if (typeof sessionStorage !== 'undefined')
    {
      console.warn(sessionStorage);
      return sessionStorage.getItem('token');
    }
 
    return null;
  }

  isConnected():boolean{

    return this._currentUserSubject.value !==null;
  }

  isAdmin():boolean{

    return this.currentUser?.role == 'Admin';
  }

  isNurse():boolean{

    return this.currentUser?.role == 'Nurse'
  }

  isMedic():boolean{

    return this.currentUser?.role == 'Medic'
  }

  isPatient():boolean{

    return this.currentUser?.role == 'Patient'
  }
}
