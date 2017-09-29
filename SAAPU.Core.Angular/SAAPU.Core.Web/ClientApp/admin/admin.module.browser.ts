import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AdminModuleShared } from './admin.module.shared';

@NgModule({
    bootstrap: [],
    imports: [
        BrowserModule,
        AdminModuleShared
    ],
    providers: [
        { provide: 'BASE_URL', useFactory: getBaseUrl }
    ]
})
export class AdminModule {
}

export function getBaseUrl() {
    return document.getElementsByTagName('base')[0].href;
}
