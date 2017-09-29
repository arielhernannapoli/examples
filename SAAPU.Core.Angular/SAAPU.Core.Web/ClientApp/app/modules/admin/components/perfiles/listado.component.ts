import { Component, OnInit } from '@angular/core';
import { Router, ParamMap, ActivatedRoute } from "@angular/router";

@Component({
    selector: 'app-perfilesListado',
    templateUrl: './listado.component.html'
})

  export class PerfilesListadoComponent implements OnInit {

    title = "Listado de Perfiles de Administradores";
  
    constructor(
      private router: Router,
      private route: ActivatedRoute) 
    { 
      
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

      }
  }
