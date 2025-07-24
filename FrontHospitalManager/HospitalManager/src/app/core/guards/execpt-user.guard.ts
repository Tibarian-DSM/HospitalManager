import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { AuthService } from '../../auth/services/auth.service';

export const execptUserGuard: CanActivateFn = (route, state) => {
  const authService = inject(AuthService);
  const router = inject(Router);

  if (authService.isMedic()|| authService.isAdmin()|| authService.isNurse()) {
    return true;
  } else {
    router.navigate(['/']);
    alert('Accès non autorisé')
    return false;
  }
};
