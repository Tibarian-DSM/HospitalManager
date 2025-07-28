import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { AbstractControl, FormBuilder, ReactiveFormsModule, ValidationErrors, ValidatorFn, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { MedicService } from '../services/medic.service';
import { MedicFormMod } from '../models/MedicFormModel';
import { ServiceService } from '../../ServicesFeatures/services/service.service';
import { ServicesMod } from '../../ServicesFeatures/models/servicesModel';


@Component({
  selector: 'app-add-medic',
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './add-medic.component.html',
  styleUrl: './add-medic.component.scss'
})
export class AddMedicComponent {

    private _fb : FormBuilder = inject(FormBuilder)
    private _router=inject(Router)
    private _service= inject(MedicService)
    private _hServices=inject(ServiceService)

    private _medic!:MedicFormMod
    public serviceList: ServicesMod[] = []

    ngOnInit()
        {
            this.getAllServices()
        }

    medicForm = this._fb.group(
    {
      firstname : [null,[Validators.required, Validators.maxLength(100)]],
      lastname : [null,[Validators.required ,Validators.maxLength(100)]],
      email: [null,[Validators.required,Validators.email]],
      password: [null, [Validators.required,Validators.pattern(/^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[#?!@$%^&*-]).{8,}$/)]],
      service: [null,[Validators.required]],
      speciality: [null,[Validators.required],Validators.maxLength(50)],
      contract:[null,[Validators.required],Validators.maxLength(32)],
      hireDate:[null,[Validators.required]],
      contractEnd:[null,[this.notBeforeHire]],
      inami:[null, [Validators.required,Validators.pattern(/^\d{11}$/),Validators.maxLength(11)]],
      is_Subsized:[null]
    }
  )

  addSubmit(){

    if(this.medicForm.invalid)
    {
      this.medicForm.markAllAsTouched();
      return ; 
    }
    this._medic = 
    {
      firstName:this.medicForm.value.firstname || '',
      lastName:this.medicForm.value.lastname || '',
      email:this.medicForm.value.email || '',
      password:this.medicForm.value.password || '',
      service_Id:Number(this.medicForm.value.service) || -1,
      speciality:this.medicForm.value.speciality|| '',
      contract:this.medicForm.value.contract || '',
      hireDate:this.medicForm.value.hireDate || new Date(),
      contractEnd:this.medicForm.value.contractEnd || null,
      inami:this.medicForm.value.inami || '',
      is_Subsized:this.medicForm.value.is_Subsized || false
    }

    this._service.addNewMedic(this._medic).subscribe(
      {
        next:() =>
          {
            alert(`Dr.${this._medic.firstName} ${this._medic.lastName} ajouté `)
            this._router.navigate(['/admin-display-users'])
          }, 
        error:(error) =>
        {
          console.log('Error',error)
        }
      });
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

      notBeforeHire(): ValidatorFn {
  return (control: AbstractControl): ValidationErrors | null => {
    const inputValue = control.value;

    if(!inputValue)
    {
      return null;
    }

    const parent = control.parent;

    if(!parent)
    {
      return null
    }

    const hireDate = parent.get('hireDate')?.value as Date

    // on supprime l'heure pour comparer uniquement la date
    hireDate.setHours(0, 0, 0, 0);
    inputValue.setHours(0, 0, 0, 0);

    return inputValue < hireDate ? { notBeforeHire: true } : null;
  };
}
}
