import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { AuthService } from '../../auth/services/auth.service';


export const ownInfoGuard: CanActivateFn = (route, state) => {
        const authService = inject(AuthService);
        const router = inject(Router); 
        const sessionUser= sessionStorage.getItem('user')

        if(!sessionUser)
        {
           router.navigate(['/login']);
          return false;
        }

        const currentUser = JSON.parse(sessionUser);
        const userId= currentUser.id;
        const routeId= +route.params['id'];
        

      if (userId === routeId|| authService.isAdmin()) 
        {
              return true;
        } 
        else 
        {
          router.navigate(['/']);
          alert('Accès non autorisé')
          return false;
        }
};
