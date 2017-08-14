using System.Collections.Generic;

namespace WPFTest.Servicios.Interfaces
{
    public interface ITestService
    {
        void insertUsuario(Model.Usuario usuario);
        void updateUsuario(Model.Usuario usuario);
        void deleteUsuario(Model.Usuario usuario);
        List<Model.Usuario> getUsuarios();
    }
}
