import { Component, inject } from '@angular/core';
import { AdminService } from '../services/admin.service';
import { basicUser } from '../models/basicUserModel';

@Component({
  selector: 'app-display-users',
  imports: [],
  templateUrl: './display-users.component.html',
  styleUrl: './display-users.component.scss'
})
export class DisplayUsersComponent {

private _service:AdminService = inject(AdminService)
public users:basicUser[] = []

    ngOnInit() {

    this.getAll();
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


}
