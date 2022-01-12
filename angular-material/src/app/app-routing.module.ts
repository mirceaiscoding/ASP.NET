import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './guards/auth.guard';
import { RoleGuard } from './guards/role.guard';
import { AppointmentsComponent } from './pages/appointments/appointments.component';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { DoctorsPresentationComponent } from './pages/doctors-presentation/doctors-presentation.component';
import { HomepageComponent } from './pages/homepage/homepage.component';
import { LoginComponent } from './pages/login/login.component';
import { MakeAppointmentComponent } from './pages/make-appointment/make-appointment.component';
import { PacientProfileComponent } from './pages/pacient-profile/pacient-profile.component';
import { ProceduresComponent } from './pages/procedures/procedures.component';
import { RegisterComponent } from './pages/register/register.component';

const routes: Routes = [
  { 
    path: '',
    redirectTo: '/home',
    pathMatch: 'full' 
  },
  { 
    path: 'home', 
    component: HomepageComponent 
  },
  { 
    path: 'doctors', 
    component: DoctorsPresentationComponent 
  },
  { 
    path: 'appointments',
    component: AppointmentsComponent,
    canActivate: [AuthGuard, RoleGuard],
    data: {roles: ["Admin"]}

  },
  { 
    path: 'dashboard', 
    component: DashboardComponent, 
    canActivate: [AuthGuard],
  },
  { 
    path: 'login', 
    component: LoginComponent 
  },
  { 
    path: 'register', 
    component: RegisterComponent 
  },
  { 
    path: 'services', 
    component: ProceduresComponent },
  {
    path: 'profile/:id',
    component: PacientProfileComponent,
    canActivate: [AuthGuard, RoleGuard],
    data: {roles: ["Pacient"]}  
  },
  { 
    path: 'make-appointment/:id', 
    component: MakeAppointmentComponent, 
    canActivate: [AuthGuard, RoleGuard],
    data: {roles: ["Pacient"]}
  },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }