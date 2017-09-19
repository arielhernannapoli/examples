import { ModuleWithProviders } from '@angular/core';
import { Route, Routes, RouterModule} from '@angular/router';

import { LoginComponent } from './login.component';

const loginRoutes: Routes = [
    { 
        path: 'login', 
        component: LoginComponent,
        children: [
            
        ]
    }
];

export const loginRoutingProviders: any[] = [];

export const routing : ModuleWithProviders = RouterModule.forChild(loginRoutes);