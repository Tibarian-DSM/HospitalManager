import { Component, inject } from '@angular/core';
import { AdminService } from '../services/admin.service';
import { basicUser } from '../../User/Models/basicUserModel';
import { FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from '../../User/Services/user.service';

@Component({
  selector: 'app-display-users',
  imports: [],
  templateUrl: './display-users.component.html',
  styleUrl: './display-users.component.scss'
})
export class DisplayUsersComponent {

private _service:AdminService = inject(AdminService)
private _userServ:UserService =inject(UserService)
public users:basicUser[] = [] 
private router:Router = inject(Router)


    ngOnInit() {

    this.getAll();
}



detailsPatient(id:number)
{
  this.router.navigate(['/patient-info', id]);
}

detailsMedic(id:number)
{
  this.router.navigate(['/medic-details', id])
}

modifierPatient(id:number)
{
  this.router.navigate(['/update-patient',id])
}

  getAll()
  {
    this._service.getAllUsers().subscribe({
      next:(res) =>{

        this.users = res;
      },
      error:(error)=>{

        console.error('erreur de chargement des utilisateurs',error)
      }
    });

  }

  getByRole(role:string)
  {
    this._userServ.getUsersByRole(role).subscribe(
      {
        next:(res) => 
        {
          this.users =res;
        },
        error:(error)=>{

        console.error('erreur de chargement des utilisateurs',error)
        }
      }
    );
  }


}
