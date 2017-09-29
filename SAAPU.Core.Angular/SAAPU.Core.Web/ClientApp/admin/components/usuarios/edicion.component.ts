import { Component, OnInit } from '@angular/core';
import { Router, ParamMap, ActivatedRoute } from "@angular/router";

import { Usuario } from './model/usuario';
import { UsuariosserviceService } from './service/usuariosservice.service';

import {PerfilesService } from '../perfiles/service/perfilesService.service';

import { Perfil } from '../perfiles/model/perfiles';

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
  perfiles: Perfil[];
  model: Usuario;

  constructor(
      private usuarioService: UsuariosserviceService,
      private perfilesService: PerfilesService, 
      private router: Router,
      private route: ActivatedRoute) 
  { 
    this.params = this.route.params.subscribe(
      params => {
        this.id = params['id'];            
      }
    );
    
    if(this.id==0 || this.id==null) {
      this.model = new Usuario(0, '', '', '');
      this.title = "Alta de Usuario";   
    }
    else {
      this.model = new Usuario(0, '', '', '');
      this.usuarioService.getUsuarioById(this.id).then(data => {
        this.model = data;
      })
      this.title = "Edicion de Usuario";         
    }
    this.perfilesService.getProfile().then(data => {
      this.perfiles = data;
    })    
  }

  ngOnInit() {
  }

  onSubmit() {    
    if(this.id==0 || this.id==null) {
      this.usuarioService.totalLength().then(data => {
        this.usuarioService.insertUsuario(new Usuario(
          data+1, 
          this.model.nombre,
          this.model.usuario,
          this.model.perfil
        )).then(data => {
          this.router.navigate(['admin/usuarios']);
        });
      })

    }
    else {
      this.usuarioService.updateUsuario(this.model).then(data => {
        this.router.navigate(['admin/usuarios']);
      });
    }
    
  }

  onCancelar() {
    this.router.navigate(['admin/usuarios']);
  }

}
