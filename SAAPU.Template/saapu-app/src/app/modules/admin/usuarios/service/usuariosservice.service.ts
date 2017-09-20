import { Injectable } from '@angular/core';

import { Usuario } from '../model/usuario';
import { USUARIOS } from '../mock/mock-usuarios';

@Injectable()
export class UsuariosserviceService {
  
  usuarios: Usuario[];

  constructor() {
    this.usuarios = USUARIOS;
  }

  getUsuarios() { 
    return this.usuarios; 
  }

  insertUsuario(usuario: Usuario) {    
    this.usuarios.push(usuario);
  }

  getCantidadUsuarios() {
    return this.usuarios.length;
  }
    
  getUsuarioById(id: number) {
    return this.usuarios.find(p=>p.id == id);
  }

  deleteUsuario(id: number) {
    let indiceElemento = this.usuarios.indexOf(this.getUsuarioById(id),0);
    if(indiceElemento>-1) {
      this.usuarios = this.usuarios.splice(1,1);
    }    
  }

  updateUsuario(usuario : Usuario) {
    this.usuarios.find(p=>p.id == usuario.id)
      .nombre = usuario.nombre;
    
    this.usuarios.find(p=>p.id == usuario.id)
      .usuario = usuario.usuario;
  }
}
