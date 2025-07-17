import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { AuthService } from '../../auth/services/auth.service';

export const medicGuard: CanActivateFn = (route, state) => {
    const authService = inject(AuthService);
  const router = inject(Router);

  if (authService.isMedic()) {
    return true;
  } else {
    router.navigate(['/']);
    alert('Accès non autorisé')
    return false;
  }
}
