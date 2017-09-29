import { Component, OnInit } from '@angular/core';
import { Router, ParamMap, ActivatedRoute } from "@angular/router";

import { Usuario } from './model/usuario';
import { UsuariosserviceService } from './service/usuariosservice.service';

@Component({
  selector: 'app-usuarioslistado',
  templateUrl: './templates/usuarioslistado.component.html',
  styleUrls: ['./styles/usuarioslistado.component.css']
})

export class UsuarioslistadoComponent implements OnInit {

  usuarios : Usuario[];
  title = "Listado de Usuarios";

  constructor(
    private usuarioService: UsuariosserviceService, 
    private router: Router,
    private route: ActivatedRoute) 
  { 
    usuarioService.getUsuarios().then(data => {
      this.usuarios = data;
    });    
  }

  ngOnInit() {

  }

  onCrearUsuarioClick() {
    this.router.navigate(['admin/usuarios/edit']);
  }

  onEditarUsuarioClick(id: number) {
    this.router.navigate(['admin/usuarios/edit', id]);
  }

  onEliminarUsuarioClick(id: number) {
    this.usuarioService.deleteUsuario(id).then(data => {
      this.usuarioService.getUsuarios().then(data => {
        this.usuarios = data;
      });
    });
    
  }

}
