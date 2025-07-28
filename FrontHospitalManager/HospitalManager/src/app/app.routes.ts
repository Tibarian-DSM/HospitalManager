import { Routes } from '@angular/router';
import { HomeComponent } from './Shared/home/home.component';
import { RegisterComponent } from './auth/register/register.component';
import { LoginComponent } from './auth/login/login.component';
import { DisplayUsersComponent } from './features/adminPanel/display-users/display-users.component';
import { adminGuard } from './core/guards/admin.guard';
import { nurseGuard } from './core/guards/nurse.guard';
import { medicGuard } from './core/guards/medic.guard';
import { execptUserGuard } from './core/guards/execpt-user.guard';
import { AddMedicComponent } from './features/Medic/add-medic/add-medic.component';
import { MedicDetailsComponent } from './features/Medic/medic-details/medic-details.component';
import { DisplayMedicsComponent } from './features/Medic/display-medics/display-medics.component';
import { patientGuard } from './core/guards/patient.guard';
import { ownInfoGuard } from './core/guards/own-info.guard';

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
        .then(m => m.UpdatePfileComponent), canActivate:[execptUserGuard]},
    {path:"add-new-medic", component:AddMedicComponent, canActivate:[adminGuard]},
    {path:"medic-details/:id",loadComponent :()=> 
        import('./features/Medic/medic-details/medic-details.component')
        .then(m => m.MedicDetailsComponent), canActivate:[adminGuard]},
    {path:"medic-list", component:DisplayMedicsComponent, canActivate:[patientGuard]},
    {path:"createAppointement/:id",loadComponent :()=> 
        import('./features/Appointement/create-appointement/create-appointement.component')
        .then(m => m.CreateAppointementComponent), canActivate:[patientGuard]},
    {path:"patient-appointements/:id",loadComponent :()=> 
        import('./features/Appointement/get-appointement-patient/get-appointement-patient.component')
        .then(m => m.GetAppointementPatientComponent), canActivate:[ownInfoGuard]},
    {path:"medic-appointements/:id",loadComponent :()=> 
        import('./features/Appointement/get-appointement-medic/get-appointement-medic.component')
        .then(m => m.GetAppointementMedicComponent), canActivate:[ownInfoGuard]},

];
