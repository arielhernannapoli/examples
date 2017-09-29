import { Component, OnInit } from '@angular/core';
import { Router, ParamMap, ActivatedRoute } from "@angular/router";

import 'rxjs/add/operator/switchMap';

@Component({
  selector: 'app-usuariosedicion',
  templateUrl: './edicion.component.html'
})
export class UsuariosedicionComponent implements OnInit {

  params: any;
  id: any;
  title: string;

  constructor(
      private router: Router,
      private route: ActivatedRoute) 
  { 
    this.params = this.route.params.subscribe(
      params => {
        this.id = params['id'];            
      }
    );
    
    if(this.id==0 || this.id==null) {      
      this.title = "Alta de Usuario";   
    }
    else {      
      this.title = "Edicion de Usuario";         
    }

  }

  ngOnInit() {
  }

  onSubmit() {    
    
  }

  onCancelar() {
    this.router.navigate(['admin/usuarios']);
  }

}
