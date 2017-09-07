using System.Collections.Generic;
using Example.Model.DTO;

namespace Example.Business.Interfaces
{
    public interface IUsuarioService
    {
        List<Usuario> getUsuarios();
    }
}