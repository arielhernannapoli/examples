import { NgModule } from '@angular/core';
import { ServerModule } from '@angular/platform-server';
import { AdminModuleShared } from './admin.module.shared';

@NgModule({
    bootstrap: [],
    imports: [
        ServerModule,
        AdminModuleShared
    ]
})
export class AdminModule {
}
