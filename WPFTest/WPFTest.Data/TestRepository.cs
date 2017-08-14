using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFTest.Data.Interfaces;
using WPFTest.Model;
using WPFTest.Model.DTO;

namespace WPFTest.Data
{
    public class TestRepository : ITestRepository
    {
        private WpfTestEntities _context;

        public TestRepository()
        {
            _context = new WpfTestEntities();
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
