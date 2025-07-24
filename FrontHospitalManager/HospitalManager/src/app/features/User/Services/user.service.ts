import { Injectable } from '@angular/core';
import { environnement } from '../../../../environement/environement';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { API_CONST } from '../../../core/api.constants';
import { basicUser } from '../Models/basicUserModel';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  
   private _apiUrl = environnement.apiUrl;
    
    constructor(private _client:HttpClient) { }

    getUserById(id:number):Observable<basicUser>
    {

      return this._client.get<basicUser>(`${this._apiUrl}/${API_CONST.User.getUserById}/${id}`)
    }

    getUsersByRole(role:string)
    {
      return this._client.get<basicUser[]>(`${this._apiUrl}/${API_CONST.User.getUsersByRole}/${role}`)
    }
}
