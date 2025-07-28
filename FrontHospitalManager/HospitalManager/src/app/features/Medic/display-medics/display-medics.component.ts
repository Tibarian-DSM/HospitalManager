import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { MedicLowMod } from '../models/medicLowModels';
import { ServicesMod } from '../../ServicesFeatures/models/servicesModel';
import { MedicService } from '../services/medic.service';
import { ServiceService } from '../../ServicesFeatures/services/service.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-display-medics',
  imports: [CommonModule],
  templateUrl: './display-medics.component.html',
  styleUrl: './display-medics.component.scss'
})
export class DisplayMedicsComponent {

    private _router=inject(Router)
    private _service= inject(MedicService)
    private _hServices=inject(ServiceService)

    public medics:MedicLowMod[]=[]
    public serviceList: ServicesMod[] = []
    public serviceId:number = 1;

    ngOnInit()
        {
            this.getAllServices()
            this.getMedicByService(this.serviceId)
        }

  getMedicByService(id:number)
  {
      console.log("Appel à getMedicByService avec ID", id);
    this._service.getMedicByService(id).subscribe(
      {
        next:(res)=>
        {
          this.medics=res;
        },
        error:(error)=>
        {
          console.error(error)
        }
      }
    )
  }

  getAllServices()
  {

    this._hServices.getAllServices().subscribe(
      {
        next:(res) =>
        {
          this.serviceList = res;
        },
        error:(error)=>
        {
          console.error(error)
        }
      }
    )

  }

  changeServiceId(id:number)
  {
    this.serviceId= id;
    this.getMedicByService(id)
  }

  redirectToAppointement(id:number)
  {
    this._router.navigate(['/createAppointement',id])
  }

}
