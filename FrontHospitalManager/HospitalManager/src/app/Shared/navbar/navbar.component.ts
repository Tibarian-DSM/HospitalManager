import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { AuthService } from '../../auth/services/auth.service';

@Component({
  selector: 'app-navbar',
  imports: [RouterLink, CommonModule],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.scss'
})
export class NavbarComponent {

   constructor(public auth:AuthService, private router:Router) {}

   public menuOpen:boolean = false
   
  logout():void{
    this.auth.logout();
    this.router.navigate(['/']);
  }

  redirectLogin():void{
      this.router.navigate(['/login']);
  }

  redirectRegister():void{
      this.router.navigate(['/register']);
  }
  redirectAdminDisplayUser():void{
      this.router.navigate(['/admin-display-users']);
  }
  redirectDisplayMedic():void
  {
    this.router.navigate(['/medic-list']);
  
  }

  redirectPatientAppointement():void
  {
    console.log(this.auth.currentUser?.id)
        this.router.navigate(['/patient-appointements',this.auth.currentUser?.id]);
  }

    redirectMedicAppointement():void
  {
        this.router.navigate(['/medic-appointements',this.auth.currentUser?.id]);
  }

  toogleMenu(event:Event)
  {
    event.preventDefault();
    this.menuOpen= !this.menuOpen
  }

}
