import { ModuleWithProviders } from '@angular/core';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NgForm, FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        HomeComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'admin', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },            
            { path: 'admin', loadChildren: 'app/modules/admin/admin.module.browser#AdminModule' },
            { path: '**', redirectTo: 'home' }
        ], { enableTracing: true})
    ]
})
export class AppModuleShared {
}
