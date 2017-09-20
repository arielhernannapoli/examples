import { TestBed, inject } from '@angular/core/testing';

import { UsuariosserviceService } from './usuariosservice.service';

describe('UsuariosserviceService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [UsuariosserviceService]
    });
  });

  it('should ...', inject([UsuariosserviceService], (service: UsuariosserviceService) => {
    expect(service).toBeTruthy();
  }));
});
