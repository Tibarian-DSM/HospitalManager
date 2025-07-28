import { Injectable } from '@angular/core';
import { environnement } from '../../../../environement/environement';
import { HttpClient } from '@angular/common/http';
import { basicUser } from '../../User/Models/basicUserModel';
import { Observable } from 'rxjs';
import { API_CONST } from '../../../core/api.constants';
import { currentUser } from '../../../auth/models/currentUserModel';
import { AuthService } from '../../../auth/services/auth.service';

@Injectable({
  providedIn: 'root'
})
export class AdminService {

    private _apiUrl = environnement.apiUrl;
  
  constructor(private _client:HttpClient ) { }

  getAllUsers(): Observable<basicUser[]>
  {

    return this._client.get<basicUser[]>(`${this._apiUrl}/${API_CONST.Admin.GetAll}`);
  }

}
