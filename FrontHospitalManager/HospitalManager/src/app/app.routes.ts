import { Routes } from '@angular/router';
import { HomeComponent } from './Shared/home/home.component';
import { RegisterComponent } from './auth/register/register.component';

export const routes: Routes = [

    {path:'',component:HomeComponent},
    {path:'register',component:RegisterComponent},
    
];
