import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule} from '@angular/router';

import { AppComponent } from './app.component';
import { AppErrorComponent } from './app-error.component';

const appRoutes: Routes = [
    { 
        path: '', 
        redirectTo: 'login',
        pathMatch: 'full'
    },
    { path: 'index', component: AppComponent },
    { path: 'login', loadChildren: 'app/modules/login/login.module#LoginModule' },
    { path: 'admin', loadChildren: 'app/modules/admin/admin.module#AdminModule' },
    { path: 'home', loadChildren: 'app/modules/home/home.module#HomeModule' },
    { path: '**', component: AppErrorComponent}
];

export const appRoutingProviders: any[] = [];

export const routing: ModuleWithProviders = RouterModule.forRoot(appRoutes, { enableTracing: false});
