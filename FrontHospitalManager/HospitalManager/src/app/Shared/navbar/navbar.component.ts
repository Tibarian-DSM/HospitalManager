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

    private _currentUser!:any 
    private _currentUserId!:number 


   public menuOpen:boolean = false

 ngOnInit(): void {
 
    if (typeof window !== 'undefined') {
      const sessionUser = sessionStorage.getItem('user');
      if (sessionUser) {
        try {
          this._currentUser = JSON.parse(sessionUser);
          this._currentUserId = this._currentUser?.id ?? null;
        } catch (error) {
          console.error('Erreur parsing sessionStorage user:', error);
        }
      }
    }
  }
   
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
        this.router.navigate(['/patient-appointements',this._currentUserId]);
  }

    redirectMedicAppointement():void
  {
        this.router.navigate(['/medic-appointements',this._currentUserId]);
  }

  toogleMenu(event:Event)
  {
    event.preventDefault();
    this.menuOpen= !this.menuOpen
  }

}
