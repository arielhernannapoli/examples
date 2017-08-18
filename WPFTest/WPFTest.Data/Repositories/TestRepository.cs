using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WPFTest.Data.Interfaces;
using WPFTest.Model.DTO;

namespace WPFTest.Data
{
    public class TestRepository : BaseRepository<usuario>, ITestRepository
    {
        public TestRepository()
        {

        }

        public TestRepository(DbContext context)
        {
            this._context = context;
        }

        public void deleteUsuario(object id)
        {
            var usuario = base.GetByID(id);
            base.Delete(usuario);
            _context.SaveChanges();
        }

        public void addUsuario(usuario Usuario)
        {
            var _usuariosSet = _context.Set<usuario>();
            _usuariosSet.Add(Usuario);
            _context.SaveChanges();
        }

        public void updateUsuario(usuario Usuario)
        {
            var usuario = base.GetByID(Usuario.id);
            usuario.nombre = Usuario.nombre;
            usuario.apellido = Usuario.apellido;
            usuario.activo = Usuario.activo;
            _context.Entry(usuario).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
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
                               Activo = (bool)u.activo
                           }).ToList();

            return usuarios;
        }
        
    }
}
