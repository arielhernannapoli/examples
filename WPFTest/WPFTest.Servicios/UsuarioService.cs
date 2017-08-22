using System.Collections.Generic;
using WPFTest.Servicios.Interfaces;
using WPFTest.Data;
using WPFTest.Data.Interfaces;
using AutoMapper;
using System.Linq;

namespace WPFTest.Servicios
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        public void insertUsuario(Model.Usuario usuario)
        {
            _usuarioRepository.addUsuario(Mapper.Map<Model.Usuario, Data.usuario>(usuario));
        }

        public void updateUsuario(Model.Usuario usuario)
        {
            _usuarioRepository.updateUsuario(Mapper.Map<Model.Usuario, Data.usuario>(usuario));
        }

        public void deleteUsuario(Model.Usuario usuario)
        {
            _usuarioRepository.deleteUsuario(usuario.Id);
        }

        public List<Model.Usuario> getUsuarios()
        {
            IEnumerable<Model.DTO.UsuarioDTO> usuariosList = null;
            usuariosList = _usuarioRepository.getUsuarios();
            var usuarios = from usuario in usuariosList
                           select Mapper.Map<Model.DTO.UsuarioDTO, Model.Usuario>(usuario);
            return usuarios.ToList();
        }

    }
}
