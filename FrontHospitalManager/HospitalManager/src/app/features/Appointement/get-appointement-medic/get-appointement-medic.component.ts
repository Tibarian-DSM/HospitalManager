import { Component, inject } from '@angular/core';
import { AppointementService } from '../services/appointement.service';
import { ActivatedRoute } from '@angular/router';
import { AppointementMod } from '../models/appointementModel';
import { error } from 'console';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-get-appointement-medic',
  imports: [CommonModule],
  templateUrl: './get-appointement-medic.component.html',
  styleUrl: './get-appointement-medic.component.scss'
})
export class GetAppointementMedicComponent {

   private _apService:AppointementService= inject(AppointementService)
      private _route = inject(ActivatedRoute)
      private _currentId!:number;

      public appointements:AppointementMod[]=[]

      ngOnInit()
      {
       this._currentId = +this._route.snapshot.params['id'];
       this.getMedicAppointement(this._currentId);
     }  

     getMedicAppointement(id:number)
     {
      this._apService.getAppointementsByMedicId(id).subscribe
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
