import { Component, inject } from '@angular/core';
import { MedicService } from '../services/medic.service';
import { MedicFullMod } from '../models/MedicFullModels';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { error } from 'console';
import { CommonModule } from '@angular/common';



@Component({
  selector: 'app-medic-details',
  imports: [CommonModule],
  templateUrl: './medic-details.component.html',
  styleUrl: './medic-details.component.scss'
})
export class MedicDetailsComponent {

   private _service:MedicService= inject(MedicService)
   private _route = inject(ActivatedRoute)
   public medic!:MedicFullMod
   private _id!:number

   ngOnInit()
   {
       this._id = +this._route.snapshot.params['id'];
       this.getMedicDetails(this._id)
   }

    getMedicDetails(id:number)
    {
      this._service.getMedicDetails(id).subscribe(
        {
          next:(res)=>
          {
            this.medic = res
          },
          error:(error)=>
          {
            console.error(error)
          }
        }
      )
    }
}
