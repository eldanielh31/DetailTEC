import { Routes } from '@angular/router';

import { DashboardComponent } from '../../pages/dashboard/dashboard.component';
import { PointsComponent } from '../../pages/points/points.component';
import { AppointmentsComponent } from '../../pages/appointments/appointments.component';
import { BillsComponent } from '../../pages/bills/bills.component';
import { LoginComponent } from '../../pages/login/login.component';
import { RegisterComponent } from '../../pages/register/register.component';
import { EventComponent } from '../../pages/event/event.component';

export const AdminLayoutRoutes: Routes = [
    { path: 'dashboard',      component: DashboardComponent },
    { path: 'points',         component: PointsComponent },
    { path: 'appointments',   component: AppointmentsComponent },
    { path: 'bills',          component: BillsComponent },
    { path: 'login',          component: LoginComponent },
    { path: 'register',       component: RegisterComponent },
    { path: 'event',          component: EventComponent }
    
];
