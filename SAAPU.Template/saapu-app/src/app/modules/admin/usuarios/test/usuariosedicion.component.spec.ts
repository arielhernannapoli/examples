import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UsuariosedicionComponent } from './usuariosedicion.component';

describe('UsuariosedicionComponent', () => {
  let component: UsuariosedicionComponent;
  let fixture: ComponentFixture<UsuariosedicionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UsuariosedicionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UsuariosedicionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
