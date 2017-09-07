using System.Collections.Generic;
using Example.Model.DTO;

namespace Example.Data.Repositories.Interfaces {
    
    public interface IUsuarioRepository {
        List<Usuario> getUsuarios();
    }
}