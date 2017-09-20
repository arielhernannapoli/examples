import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { UsuarioslistadoComponent } from './usuarios/usuarioslistado.component';
import { routing } from './admin.routing';
import { UsuariosserviceService  } from "./usuarios/service/usuariosservice.service";
import { UsuariosedicionComponent } from './usuarios/usuariosedicion.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    routing
  ],
  declarations: [UsuarioslistadoComponent, UsuariosedicionComponent],
  bootstrap: [UsuarioslistadoComponent],
  providers: [UsuariosserviceService]
})

export class AdminModule { }
