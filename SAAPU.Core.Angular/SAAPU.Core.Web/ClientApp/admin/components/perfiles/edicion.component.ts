import { Component, OnInit } from '@angular/core';
import { Router, ParamMap, ActivatedRoute } from "@angular/router";

import 'rxjs/add/operator/switchMap';

@Component({
  selector: 'app-perfilesEdicion',
  templateUrl: './edicion.component.html'
})
export class PerfilesEdicionComponent implements OnInit {

  params: any;
  id: any;
  title: string;
  model: Perfil;

  constructor(
      private perfilService: PerfilesService, 
      private router: Router,
      private route: ActivatedRoute) 
  { 
    this.params = this.route.params.subscribe(
      params => {
        this.id = params['id'];            
      }
    );
    
    if(this.id==0 || this.id==null) {
      this.model = new Perfil(0, '');
      this.title = "Alta de Perfil";   
    }
    else {
      this.model = new Perfil(0, '');
      this.perfilService.getProfileById(this.id).then(data => { this.model = data});
      this.title = "Edicion de Perfil";         
    }

  }

  ngOnInit() {
  }

  onSubmit() {    
    if(this.id==0 || this.id==null) {
      this.perfilService.totalLength().then(data => {
        this.perfilService.insertProfile(new Perfil(
          data+1, //crear un metodo para respetar el encapsulamiento
          this.model.tipoPerfil
        )).then(data => {
          this.router.navigate(['admin/perfiles']);
        }) ;
      });
    }
    else {
      this.perfilService.updateProfile(this.model).then(data=> {
        this.router.navigate(['admin/perfiles']);
      });
    }
    
  }

  onCancelar() {
    this.router.navigate(['admin/perfiles']);
  }

}
