import { Component, OnInit } from '@angular/core';
import { Router, ParamMap, ActivatedRoute } from "@angular/router";

@Component({
  selector: 'app-usuarioslistado',
  templateUrl: './listado.component.html'
})

export class UsuarioslistadoComponent implements OnInit {

  title = "Listado de Usuarios";

  constructor(
    private router: Router,
    private route: ActivatedRoute) 
  { 

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
    
  }

}
