import { Component, OnInit } from '@angular/core';
import { Router, ParamMap, ActivatedRoute } from "@angular/router";

import { Usuario } from './model/usuario';
import { UsuariosserviceService } from './service/usuariosservice.service';

import 'rxjs/add/operator/switchMap';

@Component({
  selector: 'app-usuariosedicion',
  templateUrl: './templates/usuariosedicion.component.html',
  styleUrls: ['./styles/usuariosedicion.component.css']
})
export class UsuariosedicionComponent implements OnInit {

  params: any;
  id: any;
  title: string;
  model: Usuario;

  constructor(
      private usuarioService: UsuariosserviceService, 
      private router: Router,
      private route: ActivatedRoute) 
  { 
    this.params = this.route.params.subscribe(
      params => {
        this.id = params['id'];            
      }
    );
    
    if(this.id==0 || this.id==null) {
      this.model = new Usuario(0, '', '');
      this.title = "Alta de Usuario";   
    }
    else {
      this.model = this.usuarioService.getUsuarioById(this.id);
      this.title = "Edicion de Usuario";         
    }

  }

  ngOnInit() {
  }

  onSubmit() {    
    if(this.id==0 || this.id==null) {
      this.usuarioService.insertUsuario(new Usuario(
        this.usuarioService.getCantidadUsuarios()+1, 
        this.model.nombre,
        this.model.usuario
      ));
    }
    else {
      this.usuarioService.updateUsuario(this.model);
    }
    this.router.navigate(['admin']);
  }

  onCancelar() {
    this.router.navigate(['admin']);
  }

}
