using System.Collections.Generic;
using WPFTest.Servicios.Interfaces;
using WPFTest.Data;
using WPFTest.Data.Interfaces;
using AutoMapper;
using System.Linq;

namespace WPFTest.Servicios
{
    public class TestService : ITestService
    {
        private readonly ITestRepository _testRepository;

        public TestService()
        {
            _testRepository = new TestRepository();
        }

        public void insertUsuario(Model.Usuario usuario)
        {
            _testRepository.addUsuario(Mapper.Map<Model.Usuario, Data.usuario>(usuario));
        }

        public void updateUsuario(Model.Usuario usuario)
        {
            _testRepository.updateUsuario(Mapper.Map<Model.Usuario, Data.usuario>(usuario));
        }

        public void deleteUsuario(Model.Usuario usuario)
        {
            _testRepository.deleteUsuario(usuario.Id);
        }

        public List<Model.Usuario> getUsuarios()
        {
            IEnumerable<Model.DTO.UsuarioDTO> usuariosList = null;
            usuariosList = _testRepository.getUsuarios();
            var usuarios = from usuario in usuariosList
                           select Mapper.Map<Model.DTO.UsuarioDTO, Model.Usuario>(usuario);
            return usuarios.ToList();
        }

    }
}
