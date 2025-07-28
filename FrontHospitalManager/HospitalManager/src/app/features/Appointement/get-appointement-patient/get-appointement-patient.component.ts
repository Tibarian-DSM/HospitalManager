import { Component, inject } from '@angular/core';
import { AppointementService } from '../services/appointement.service';
import { ActivatedRoute } from '@angular/router';
import { AppointementMod } from '../models/appointementModel';
import { error } from 'console';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-get-appointement-patient',
  imports: [CommonModule],
  templateUrl: './get-appointement-patient.component.html',
  styleUrl: './get-appointement-patient.component.scss'
})
export class GetAppointementPatientComponent {

      private _apService:AppointementService= inject(AppointementService)
      private _route = inject(ActivatedRoute)
      private _currentId!:number;

      public appointements:AppointementMod[]=[]

      ngOnInit()
      {
       this._currentId = +this._route.snapshot.params['id'];
       this.getPatientAppointement(this._currentId);
     }  

     getPatientAppointement(id:number)
     {
      this._apService.getAppointementsByPatientId(id).subscribe
      (
        {
           next:(res)=>
            {
               this.appointements=res
            },
          error:(error) =>
            {
              console.error("erreur de chargement", error)
            }
        }
      )
     }
}
