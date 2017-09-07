using Example.Data.Repositories.Interfaces;
using Example.Model.DTO;
using System.Collections.Generic;
using System.Linq;
using Example.Data.Entities;

namespace Example.Data.Repositories {

    public class UsuarioRepository : BaseRepository<usuario>, IUsuarioRepository  {

        public UsuarioRepository(ExampleDbEntities context) : base(context) {

        }   

        public List<Usuario> getUsuarios() {

            IQueryable<usuario> usuarioSet = _context.Set<usuario>();

            var usuarios = (from u in usuarioSet
                           select new Usuario
                           {
                               Id = (int)u.id,
                               Nombre = u.nombre,
                               Apellido = u.apellido,
                               NombreUsuario = u.usuario1,
                               Activo = (bool)u.activo
                           }).ToList();

            return usuarios;

        }
    }
}