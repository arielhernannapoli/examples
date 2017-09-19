import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule} from '@angular/router';

import { AppComponent } from './app.component';

const appRoutes: Routes = [
    { 
        path: '', 
        redirectTo: 'login',
        pathMatch: 'full'
    },
    { path: 'index', component: AppComponent },
    { path: 'login', loadChildren: './login/login.module#LoginModule'}
];

export const appRoutingProviders: any[] = [];

export const routing: ModuleWithProviders = RouterModule.forRoot(appRoutes);
