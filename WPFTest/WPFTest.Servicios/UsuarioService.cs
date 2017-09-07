using System.Collections.Generic;
using WPFTest.Servicios.Interfaces;
using WPFTest.Data;
using WPFTest.Data.Interfaces;
using AutoMapper;
using System.Linq;
using WPFTest.Services;

namespace WPFTest.Servicios
{
    public class UsuarioService : GenericService, IUsuarioService
    {
        private readonly int? usuarioId = 0;
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService() : base()
        {
            _usuarioRepository = new UsuarioRepository(_uow);
        }

        public void insertUsuario(Model.Usuario usuario)
        {
            _usuarioRepository.Insert(Mapper.Map<Model.Usuario, Data.usuario>(usuario));
            _uow.SaveChanges(usuarioId);
        }

        public void updateUsuario(Model.Usuario usuario)
        {
            _usuarioRepository.Update(Mapper.Map<Model.Usuario, Data.usuario>(usuario));
            _uow.SaveChanges(usuarioId);
        }

        public void deleteUsuario(Model.Usuario usuario)
        {
            _usuarioRepository.Delete(usuario.Id);
            _uow.SaveChanges(usuarioId);
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
