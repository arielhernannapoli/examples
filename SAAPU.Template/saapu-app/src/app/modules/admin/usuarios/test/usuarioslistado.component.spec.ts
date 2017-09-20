import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UsuarioslistadoComponent } from './usuarioslistado.component';

describe('UsuarioslistadoComponent', () => {
  let component: UsuarioslistadoComponent;
  let fixture: ComponentFixture<UsuarioslistadoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UsuarioslistadoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UsuarioslistadoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
