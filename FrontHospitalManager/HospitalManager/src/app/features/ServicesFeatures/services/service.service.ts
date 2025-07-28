import { Injectable } from '@angular/core';
import { environnement } from '../../../../environement/environement';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ServicesMod } from '../models/servicesModel';
import { API_CONST } from '../../../core/api.constants';

@Injectable({
  providedIn: 'root'
})
export class ServiceService {

   private _apiUrl = environnement.apiUrl;
    
    constructor(private _client:HttpClient) { }

    getAllServices():Observable<ServicesMod[]>
    {
      return this._client.get<ServicesMod[]>(`${this._apiUrl}/${API_CONST.Service.getAllServices}`)
    }

    addNewService(name:string)
    {
      return this._client.post<string>(`${this._apiUrl}/${API_CONST.Service.addNewService}`,name)
    }

    removeService(id:number)
    {
      return this._client.delete<number>(`${this._apiUrl}/${API_CONST.Service.deleteService}/${id}`)
    }
}
