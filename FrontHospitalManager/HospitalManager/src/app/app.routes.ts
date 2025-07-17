import { Routes } from '@angular/router';
import { HomeComponent } from './Shared/home/home.component';
import { RegisterComponent } from './auth/register/register.component';
import { LoginComponent } from './auth/login/login.component';
import { DisplayUsersComponent } from './features/adminPanel/display-users/display-users.component';
import { adminGuard } from './core/guards/admin.guard';

export const routes: Routes = [

    {path:'',component:HomeComponent},
    {path:'register',component:RegisterComponent},
    {path:'login', component:LoginComponent},
    {path:"admin-display-users",component:DisplayUsersComponent, canActivate:[adminGuard]}

];
