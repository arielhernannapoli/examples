import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router, ParamMap, ActivatedRoute } from '@angular/router';
import { Login, Permiso } from './login';

@Component({
    selector: 'home',
    templateUrl: './home.component.html'
})
export class HomeComponent implements OnInit {

    model: Login;
    title = "Sistema de Acceso A Proveedores y Usuarios";

    constructor(
        private router: Router,
        private route: ActivatedRoute
    )
    {
        this.model = new Login();
    }

    ngOnInit() {
        if (localStorage.getItem("usuario") != null) {
            this.router.navigate(["index"]);
        }
    }

    onSubmit() {
        let usuario = null;
        this.model.permisos = [];
        this.model.permisos.push(new Permiso("Administrador"));
        localStorage.setItem("usuario", JSON.stringify(this.model));
        document.location.href = document.location.href.replace("home", "admin");
    }
}
