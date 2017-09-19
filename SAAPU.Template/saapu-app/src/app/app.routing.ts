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
    { path: 'login', loadChildren: 'app/login/login.module#LoginModule' },
    { path: 'admin', loadChildren: 'app/admin/admin.module#AdminModule' },
    { path: 'home', loadChildren: 'app/home/home.module#HomeModule' }
];

export const appRoutingProviders: any[] = [];

export const routing: ModuleWithProviders = RouterModule.forRoot(appRoutes);
