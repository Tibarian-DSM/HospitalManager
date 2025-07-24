import { Injectable } from '@angular/core';
import { environnement } from '../../../../environement/environement';
import { HttpClient } from '@angular/common/http';
import { AuthService } from '../../../auth/services/auth.service';
import { Observable } from 'rxjs';
import { PatientInfoMod } from '../models/patientInfoModel';
import { API_CONST } from '../../../core/api.constants';

@Injectable({
  providedIn: 'root'
})
export class PatientService {

   private _apiUrl = environnement.apiUrl;
    
    constructor(private _client:HttpClient) { }

    getInfoPatient(id:number): Observable<PatientInfoMod | null>
    {
      return this._client.get<PatientInfoMod | null>(`${this._apiUrl}/${API_CONST.Patient.getPatientFile}/${id}`);
    }

    addNewPatientInfo(patient:PatientInfoMod)
    {
      return this._client.post<PatientInfoMod>(`${this._apiUrl}/${API_CONST.Patient.addNewPatientFile}/${patient.user_id}`,patient)
    }

    updatePatientInfo(patient:PatientInfoMod, loggedUId:number)
    {
      return this._client.patch<PatientInfoMod>(`${this._apiUrl}/${API_CONST.Patient.updatePatientFile}/${loggedUId}`,patient)
    }
}
