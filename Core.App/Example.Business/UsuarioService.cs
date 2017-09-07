using System;
using System.Collections.Generic;
using Example.Business.Interfaces;
using Example.Data.Repositories.Interfaces;
using Example.Model.DTO;
using System.Linq;
using Example.Data.Repositories;
using Example.Data;

namespace Example.Business
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        
        public UsuarioService(ExampleDbEntities _context) {
            this._usuarioRepository = new UsuarioRepository(_context);
        }

        public List<Usuario> getUsuarios()
        {
            IEnumerable<Usuario> usuariosList = null;
            usuariosList = _usuarioRepository.getUsuarios();
            return usuariosList.ToList();
        }
    }
}
