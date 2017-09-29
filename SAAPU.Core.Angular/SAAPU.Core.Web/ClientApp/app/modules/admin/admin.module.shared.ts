import { ModuleWithProviders } from '@angular/core';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NgForm, FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { PerfilesListadoComponent } from './components/perfiles/listado.component';
import { PerfilesEdicionComponent } from './components/perfiles/edicion.component';
import { UsuarioslistadoComponent } from './components/usuarios/listado.component';
import { UsuariosedicionComponent } from './components/usuarios/edicion.component';

@NgModule({
    declarations: [
        PerfilesListadoComponent,
        PerfilesEdicionComponent,
        UsuarioslistadoComponent,
        UsuariosedicionComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forChild([
            { path: 'usuarios', component: UsuarioslistadoComponent },
            { path: 'usuarios/edit', component: UsuariosedicionComponent },
            { path: 'usuarios/edit/:id', component: UsuariosedicionComponent },
            { path: 'perfiles', component: PerfilesListadoComponent },
            { path: 'perfiles/edit', component: PerfilesEdicionComponent },
            { path: 'perfiles/edit/:id', component: PerfilesEdicionComponent}
        ])
    ]
})
export class AdminModuleShared {
}
