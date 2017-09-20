import { Component, OnInit } from '@angular/core';
import { Router, ParamMap, ActivatedRoute } from "@angular/router";

@Component({
  selector: 'app-root',
  templateUrl: './templates/login.component.html',
  styleUrls: ['./styles/login.component.css']
})

export class LoginComponent implements OnInit {

  title = "Ingreso al sistema SAAPU";

  constructor(
    private router: Router,
    private route: ActivatedRoute
  ) { }

  ngOnInit() {

  }

  onSubmit() {
    this.router.navigate(['admin']);
  }

}
