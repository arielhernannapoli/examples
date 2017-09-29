import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NgForm, FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { PerfilesListadoComponent } from 'components/perfiles/listado.component';
import { PerfilesEdicionComponent } from 'components/perfiles/edicion.component';
import { UsuarioslistadoComponent } from 'components/usuarios/listado.component';
import { UsuariosedicionComponent } from 'components/usuarios/edicion.component';

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
        RouterModule.forRoot([

        ])
    ]
})
export class AdminModuleShared {
}
