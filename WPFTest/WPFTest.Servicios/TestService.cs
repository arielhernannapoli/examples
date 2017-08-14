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
