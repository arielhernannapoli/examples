using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFTest.Data.Interfaces
{
    public interface ITestRepository
    {
        List<Model.DTO.UsuarioDTO> getUsuarios();
    }
}
