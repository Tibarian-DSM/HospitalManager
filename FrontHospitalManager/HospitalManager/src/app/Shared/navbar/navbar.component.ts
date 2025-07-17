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

}
