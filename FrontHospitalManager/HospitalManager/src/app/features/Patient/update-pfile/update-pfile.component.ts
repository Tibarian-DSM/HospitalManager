import { Component, inject } from '@angular/core';
import { PatientService } from '../services/patient.service';
import { AbstractControl, FormBuilder, ReactiveFormsModule, ValidationErrors, ValidatorFn, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { PatientInfoMod } from '../models/patientInfoModel';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-update-pfile',
  imports: [ReactiveFormsModule,CommonModule],
  templateUrl: './update-pfile.component.html',
  styleUrl: './update-pfile.component.scss'
})
export class UpdatePfileComponent {

  private _service:PatientService=inject(PatientService)
  private _fb : FormBuilder = inject(FormBuilder)
  private _router = inject(ActivatedRoute)

  public id!:number;
  public patient!:PatientInfoMod|null;
  public modifierId!:number;

  patientForm = this._fb.group(
    {
      phoneNumber:['',[Validators.required, Validators.maxLength(15)]],
      adress:['',[Validators.required, Validators.maxLength(100)]],
      birthdate: ['',[Validators.required,this.notInFutureValidator]],
      medicalInfo:['',[Validators.required, Validators.maxLength(1500)]]

    })

  ngOnInit()
      {
          this.id = +this._router.snapshot.params['id'];
          if(this.getLoggedUserId() !== null)
          {
            this.modifierId=this.getLoggedUserId();
          }

          this.getInfo(this.id)
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

          this._service.updatePatientInfo(this.patient,this.modifierId).subscribe(
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

  getLoggedUserId():number
  {
    const sessionData = sessionStorage.getItem('user');

    if (!sessionData)
    {
      throw new Error("Aucune donnée utilisateur trouvée dans la session.");
    }
    
    try
    {
      const Id:number = JSON.parse(sessionData).id ;

      if(sessionData !== undefined)
      {
        return Id
      }
      else
      {
        throw new Error("Id introuvable dans la session");
      }
    }   
    catch(error)
    {
         throw new Error("Erreur lors de l'analyse des données utilisateur : " + error);
    }
    
  }

  getInfo(id:number)
        {
          this._service.getInfoPatient(id).subscribe(
            {
              next:(res)=>{

                  this.patient= res;

                  this.patientForm.patchValue(
                      {
                        phoneNumber : res?.phoneNumber,
                        adress : res?.adress,
                        birthdate: res?.birthdate,
                        medicalInfo:res?.medicalInfo
                     })
              },
              error:(error)=>
              {
                console.log('error lors du chargement du fichier',error)
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
