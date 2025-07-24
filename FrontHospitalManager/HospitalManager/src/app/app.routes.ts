import { Routes } from '@angular/router';
import { HomeComponent } from './Shared/home/home.component';
import { RegisterComponent } from './auth/register/register.component';
import { LoginComponent } from './auth/login/login.component';
import { DisplayUsersComponent } from './features/adminPanel/display-users/display-users.component';
import { adminGuard } from './core/guards/admin.guard';
import { nurseGuard } from './core/guards/nurse.guard';
import { medicGuard } from './core/guards/medic.guard';
import { execptUserGuard } from './core/guards/execpt-user.guard';

export const routes: Routes = [

    {path:'',component:HomeComponent},
    {path:'register',component:RegisterComponent},
    {path:'login', component:LoginComponent},
    {path:"admin-display-users",component:DisplayUsersComponent, canActivate:[adminGuard]},
    {path:"patient-info/:id",loadComponent :()=> 
        import('./features/Patient/get-or-create-pfile/get-or-create-pfile.component')
        .then(m => m.GetOrCreatePFileComponent), canActivate:[execptUserGuard]},
    {path:"update-patient/:id",loadComponent :()=> 
        import('./features/Patient/update-pfile/update-pfile.component')
        .then(m => m.UpdatePfileComponent), canActivate:[execptUserGuard]}

];
