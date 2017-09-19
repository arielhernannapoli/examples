import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login.component';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { routing, loginRoutingProviders } from './login.routing';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    HttpModule, 
    routing
  ],
  declarations: [
    LoginComponent
  ],
  bootstrap: [LoginComponent]
})

export class LoginModule { 

}
