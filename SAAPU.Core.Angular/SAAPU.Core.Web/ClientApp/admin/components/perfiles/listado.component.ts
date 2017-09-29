import { Component, OnInit } from '@angular/core';
import { Router, ParamMap, ActivatedRoute } from "@angular/router";

@Component({
    selector: 'app-perfilesListado',
    templateUrl: './listado.component.html'
})

  export class PerfilesListadoComponent implements OnInit {

    perfiles : Perfil[];
    title = "Listado de Perfiles de Administradores";
  
    constructor(
      private perfilService: PerfilesService, 
      private router: Router,
      private route: ActivatedRoute) 
    { 
      perfilService.getProfile().then( data => {
        this.perfiles = data;
      });
      
    }
  
    ngOnInit() {

    }

    onCrearPerfilClick() {
        this.router.navigate(['admin/perfiles/edit']);
      }
    
      onEditarPerfilClick(id: number) {
        this.router.navigate(['admin/perfiles/edit', id]);
      }
    
      onEliminarPerfilClick(id: number) {
        this.perfilService.deleteProfile(id).then(data => {
          this.perfilService.getProfile().then( data => {
            this.perfiles = data;
          });
        });
      }
  }
