import { Injectable } from '@angular/core';
import { environnement } from '../../../../environement/environement';
import { HttpClient } from '@angular/common/http';
import { MedicFullMod } from '../models/MedicFullModels';
import { API_CONST } from '../../../core/api.constants';
import { Observable } from 'rxjs';
import { MedicFormMod } from '../models/MedicFormModel';
import { MedicLowMod } from '../models/medicLowModels';

@Injectable({
  providedIn: 'root'
})
export class MedicService {

  private _apiUrl = environnement.apiUrl;
  
  constructor(private _client:HttpClient ) { }

  addNewMedic(medic:MedicFormMod)
  {
    return this._client.post<MedicFormMod>(`${this._apiUrl}/${API_CONST.Medic.addNewMedic}`,medic)
  }

  getMedicDetails(id:number):Observable<MedicFullMod>
  {
    return this._client.get<MedicFullMod>(`${this._apiUrl}/${API_CONST.Medic.getMedicDetails}/${id}`)
  }

  getMedicByService(id:number):Observable<MedicLowMod[]>
  {
    return this._client.get<MedicLowMod[]>(`${this._apiUrl}/${API_CONST.Medic.getMedicByService}/${id}`)
  }
  
}
