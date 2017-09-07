using Microsoft.VisualStudio.TestTools.UnitTesting;
using WPFTest.Data;
using WPFTest.Data.Interfaces;
using AutoMapper;
using WPFTest.Infraestructure.UoW;

namespace WPFTest.TestUnit
{
    [TestClass]
    public class TestUsuario
    {
        private readonly int? usuarioId = 0;
        private IUnitOfWork _uow;
        private IUsuarioRepository _usuarioRepository;

        [TestInitialize]
        public void InitTest()
        {
            this.ConfigurarMappings();
            IDbContextFactory factory = new DbContextFactory(Effort.DbConnectionFactory.CreateTransient());           
            this._uow = new UnitOfWork(factory);
            this._usuarioRepository = new UsuarioRepository(this._uow);
            this.FillMockData();
        }

        [TestMethod]
        public void obtenerUsuarios()
        {
            var usuarios = this._usuarioRepository.getUsuarios();
            Assert.AreEqual(usuarios.Count, 2);
        }

        [TestMethod]
        public void insertarUsuario()
        {
            int cantidadPre = this._usuarioRepository.getUsuarios().Count;
            Assert.AreEqual(cantidadPre, 2);
            var usuario = new Data.usuario()
            {
                id = 3,
                nombre = "Pablo",
                apellido = "Perez",
                usuario1 = "pperez",              
                activo = true
            };
            this._usuarioRepository.Insert(usuario);
            this._uow.SaveChanges(usuarioId);
            int cantidadPost = this._usuarioRepository.getUsuarios().Count;
            Assert.AreEqual(cantidadPost, 3);
        }

        [TestMethod]
        public void actualizarUsuario()
        {
            Data.usuario usuario = this._usuarioRepository.GetByID(1);
            Assert.AreEqual(usuario.activo, true);
            usuario.activo = false;
            this._usuarioRepository.Update(usuario);
            this._uow.SaveChanges(usuarioId);
            Assert.AreEqual(usuario.activo, false);
        }

        [TestMethod]
        public void eliminarUsuario()
        {
            Data.usuario usuario = this._usuarioRepository.GetByID(1);
            Assert.IsNotNull(usuario);
            this._usuarioRepository.Delete(1);
            this._uow.SaveChanges(usuarioId);
            usuario = this._usuarioRepository.GetByID(1);
            Assert.IsNull(usuario);
        }

        private void FillMockData()
        {
            this._usuarioRepository.Insert(new usuario() { id = 1, nombre = "Ariel", apellido = "Napoli", activo = true });
            this._usuarioRepository.Insert(new usuario() { id = 2, nombre = "Hernan", apellido = "Alzueta", activo = true });
            this._uow.SaveChanges(usuarioId);
        }

        private void ConfigurarMappings()
        {
            Mapper.Initialize(cfg =>
                cfg.AddProfiles(new[] {
                                "WPFTest.Services"
                })
            );
        }
    }
}
