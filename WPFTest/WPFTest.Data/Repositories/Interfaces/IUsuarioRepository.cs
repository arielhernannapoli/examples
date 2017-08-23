using System.Collections.Generic;

namespace WPFTest.Data.Interfaces
{
    public interface IUsuarioRepository : IBaseRepository<usuario>
    {
        List<Model.DTO.UsuarioDTO> getUsuarios();
    }
}
