import { ModuleWithProviders } from '@angular/core';
import { Route, Routes, RouterModule} from '@angular/router';

import { UsuariosedicionComponent } from './usuarios/usuariosedicion.component';
import { UsuarioslistadoComponent } from './usuarios/usuarioslistado.component';

const adminRoutes: Routes = [
    { 
        path: '', 
        component: UsuarioslistadoComponent
    },
    { path: 'edit', component: UsuariosedicionComponent },
    { path: 'edit/:id', component: UsuariosedicionComponent },

];

export const routing : ModuleWithProviders = RouterModule.forChild(adminRoutes);
