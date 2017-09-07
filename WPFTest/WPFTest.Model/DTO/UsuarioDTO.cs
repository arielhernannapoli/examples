using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFTest.Model.DTO
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public String Nombre { get; set; }
        public String Apellido { get; set; }
        public String NombreUsuario { get; set; }
        public String Usuario { get { return this.NombreUsuario; } }
        public bool Activo { get; set; }
    }
}
