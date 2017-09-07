using System.Collections.Generic;
using System.Linq;
using WPFTest.Data.Interfaces;
using WPFTest.Infraestructure.UoW;
using WPFTest.Model.DTO;

namespace WPFTest.Data
{
    public class UsuarioRepository : BaseRepository<usuario>, IUsuarioRepository
    {
        public UsuarioRepository(IUnitOfWork uow) : base(uow)
        {

        }

        public List<Model.DTO.UsuarioDTO> getUsuarios()
        {
            IQueryable<usuario> usuarioSet = _context.Set<usuario>();

            var usuarios = (from u in usuarioSet
                           select new UsuarioDTO
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
