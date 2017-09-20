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
  title = "Usuarios";

  constructor(
    private usuarioService: UsuariosserviceService, 
    private router: Router,
    private route: ActivatedRoute) 
  { 
    this.usuarios = usuarioService.getUsuarios();
  }

  ngOnInit() {

  }

  onCrearUsuarioClick() {
    this.router.navigate(['admin/edit']);
  }

  onEditarUsuarioClick(id: number) {
    this.router.navigate(['admin/edit', id]);
  }

  onEliminarUsuarioClick(id: number) {
    this.usuarioService.deleteUsuario(id);
    this.usuarios = this.usuarioService.getUsuarios();
  }

}
