import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { AbstractControl, FormBuilder, ReactiveFormsModule, ValidationErrors, ValidatorFn, Validators } from '@angular/forms';
import { PatientService } from '../services/patient.service';
import { PatientInfoMod } from '../models/patientInfoModel';
import { ActivatedRoute, Router } from '@angular/router';

import { UserService } from '../../User/Services/user.service';
import { basicUser } from '../../User/Models/basicUserModel';


@Component({
  selector: 'app-get-or-create-pfile',
  imports: [ReactiveFormsModule,CommonModule],
  templateUrl: './get-or-create-pfile.component.html',
  styleUrl: './get-or-create-pfile.component.scss'
})
export class GetOrCreatePFileComponent {

  private _service:PatientService=inject(PatientService)
  private _userServ : UserService = inject(UserService)
  private _fb : FormBuilder = inject(FormBuilder)
  private _router = inject(ActivatedRoute)
 
  public patient!:PatientInfoMod | null ;
  public user!:basicUser;
  public id!:number;

  patientForm = this._fb.group(
    {
      phoneNumber:[null,[Validators.required, Validators.maxLength(15)]],
      adress:[null,[Validators.required, Validators.maxLength(100)]],
      birthdate: [null,[Validators.required,this.notInFutureValidator]],
      medicalInfo:[null,[Validators.required, Validators.maxLength(1500)]]

    })

       ngOnInit()
        {
          this.id = +this._router.snapshot.params['id'];
          this.getUserById(this.id)
          this.getInfo(this.id);
        }

        getUserById(id:number)
        {
          this._userServ.getUserById(id).subscribe(
            {
              next : (res) =>
              {
                this.user = res;
              },
              error: (error)=>
              {
                console.error(`Erreur dans le chargement de l'utilisateur`,error)
              }
            }
          )
        }

        getInfo(id:number)
        {
          this._service.getInfoPatient(id).subscribe(
            {
              next:(res)=>{

                  this.patient= res;
              },
              error:(error)=>
              {
                console.log('error lors du chargement du fichier',error)
              }

            }
          )
        }

      PatientFileSubmit()
      {
        if(this.patientForm.invalid)
        {
          this.patientForm.markAllAsTouched();
          return ; 
        }

        this.patient =
          {
            user_id : this.id,
            phoneNumber: this.patientForm.value.phoneNumber || "",
            adress:this.patientForm.value.adress || "",
            birthdate :this.patientForm.value.birthdate || "",
            medicalInfo:this.patientForm.value.medicalInfo || ""

          }

          this._service.addNewPatientInfo(this.patient).subscribe(
            {
              next :(res)=>
              {
                alert(res);
              },
              error :(error)=>
              {
                console.warn('erreur dans la création du patient',error)
              }
            }
          )

      }

    notInFutureValidator(): ValidatorFn {
  return (control: AbstractControl): ValidationErrors | null => {
    const inputValue = control.value as Date;

    if (!inputValue) return null; // ne valide pas si vide

    const today = new Date();

    // on supprime l'heure pour comparer uniquement la date
    today.setHours(0, 0, 0, 0);
    inputValue.setHours(0, 0, 0, 0);

    return inputValue > today ? { dateInFuture: true } : null;
  };
}

}
