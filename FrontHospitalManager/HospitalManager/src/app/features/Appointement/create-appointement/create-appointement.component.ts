import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { AbstractControl, FormBuilder, ReactiveFormsModule, ValidationErrors, ValidatorFn, Validators } from '@angular/forms';
import { AppointementService } from '../services/appointement.service';
import { ActivatedRoute } from '@angular/router';
import { AppointementFormMod } from '../models/appointementFormModel';

@Component({
  selector: 'app-create-appointement',
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './create-appointement.component.html',
  styleUrl: './create-appointement.component.scss'
})
export class CreateAppointementComponent {

    private _apService:AppointementService= inject(AppointementService)
    private _route = inject(ActivatedRoute)
    private _fb : FormBuilder = inject(FormBuilder)
    private _sessionUser: string|null= sessionStorage.getItem('user')
    private _currentUser!:any 
    private _currentUserId!:number 
    private _medicId!:number

    public  appointement!:AppointementFormMod;

    apForm = this._fb.group(
    {
      ap_date:[null,[Validators.required , this.notInPastValidator]],
      ap_hour:[null,[Validators.required]],
      subject:[null,[Validators.required , Validators.maxLength(50)]]
    })

    
    ngOnInit()
   {
       this._medicId = +this._route.snapshot.params['id'];
       if(this._sessionUser)
       {
        this._currentUser= JSON.parse(this._sessionUser)
        this._currentUserId = this._currentUser.id
       }
   }

      AppointementSubmit()
      {
        if(this.apForm.invalid)
        {
          this.apForm.markAllAsTouched();
          return ; 
        }

          const dateStr: string = this.apForm.value.ap_date || ''; 
          const hourStr: string = this.apForm.value.ap_hour || ''; 

          // Conversion en Date
          const [year, month, day] = dateStr.split('-').map(Number);
          const [hour, minute] = hourStr.split(':').map(Number);

          const appointementDate = new Date(year, month - 1, day, hour, minute);

        this.appointement =
          {
            patient_Id: this._currentUserId,
            medic_Id:this._medicId,
            appointement_Date: appointementDate,
            subject:this.apForm.value.subject || ""

          }

          this._apService.createAppointement(this.appointement).subscribe(
            {
              next :()=>
              {
                alert("Le rendez-vous a bien été pris");

              },
              error :(error)=>
              {
                console.warn('erreur dans la création du rendez-vous',error)
              }
            }
          )

      }

  notInPastValidator(): ValidatorFn {
    return (control: AbstractControl): ValidationErrors | null => {
      const inputValue = control.value as Date;

      if (!inputValue) return null; // ne valide pas si vide

      const today = new Date();

      today.setHours(0, 0, 0, 0);
      inputValue.setHours(0, 0, 0, 0);

      return inputValue < today ? { dateInFuture: true } : null;
    };
}



}
