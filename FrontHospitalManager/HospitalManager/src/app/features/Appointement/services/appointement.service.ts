import { Injectable } from '@angular/core';
import { environnement } from '../../../../environement/environement';
import { HttpClient } from '@angular/common/http';
import { AppointementFormMod } from '../models/appointementFormModel';
import { API_CONST } from '../../../core/api.constants';
import { Observable } from 'rxjs';
import { AppointementMod } from '../models/appointementModel';

@Injectable({
  providedIn: 'root'
})
export class AppointementService {

    private _apiUrl = environnement.apiUrl;
  
  constructor(private _client:HttpClient ) { }


  createAppointement(appointement : AppointementFormMod)
  {
    return this._client.post<AppointementFormMod>(`${this._apiUrl}/${API_CONST.Appointement.createAppointement}`,appointement)
  }

  getAppointementById(id:number):Observable<AppointementMod>
  {
    return this._client.get<AppointementMod>(`${this._apiUrl}/${API_CONST.Appointement.getAppointementById}/${id}`)
  }

    getAppointementsByMedicId(id:number):Observable<AppointementMod[]>
  {
    return this._client.get<AppointementMod[]>(`${this._apiUrl}/${API_CONST.Appointement.getAppointementsByMedicId}/${id}`)
  }

  getAppointementsByPatientId(id:number):Observable<AppointementMod[]>
  {
    return this._client.get<AppointementMod[]>(`${this._apiUrl}/${API_CONST.Appointement.getAppointementsByPatientId}/${id}`)
  }
}
