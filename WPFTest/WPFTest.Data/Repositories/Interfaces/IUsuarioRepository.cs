using System.Collections.Generic;

namespace WPFTest.Data.Interfaces
{
    public interface IUsuarioRepository
    {
        void deleteUsuario(object id);
        void addUsuario(usuario Usuario);
        void updateUsuario(usuario Usuario);
        List<Model.DTO.UsuarioDTO> getUsuarios();
    }
}
