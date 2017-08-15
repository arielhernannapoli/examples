using Microsoft.VisualStudio.TestTools.UnitTesting;
using WPFTest.Data;
using WPFTest.Data.Interfaces;
using AutoMapper;
using System.IO;
using System;
using Effort.DataLoaders;
using System.Linq;

namespace WPFTest.TestUnit
{
    [TestClass]
    public class TestUnit
    {
        private WpfTestEntities _context;
        private ITestRepository _testRepository;

        [TestInitialize]
        public void InitTest()
        {
            this.ConfigurarMappings();
            this._context = new WpfTestEntities(Effort.DbConnectionFactory.CreateTransient());
            this.FillMockData();
            this._testRepository = new TestRepository(this._context);            
        }

        [TestMethod]
        public void obtenerUsuarios()
        {
            var usuarios = this._testRepository.getUsuarios();
            Assert.AreEqual(usuarios.Count, 2);
        }

        [TestMethod]
        public void insertarUsuario()
        {
            int cantidadPre = this._testRepository.getUsuarios().Count;
            Assert.AreEqual(cantidadPre, 2);
            var usuario = new Data.usuario()
            {
                id = 3,
                nombre = "Pablo",
                apellido = "Perez",
                usuario1 = "pperez",              
                activo = true
            };
            this._testRepository.addUsuario(usuario);
            int cantidadPost = this._testRepository.getUsuarios().Count;
            Assert.AreEqual(cantidadPost, 3);
        }

        [TestMethod]
        public void actualizarUsuario()
        {
            Data.usuario usuario = this._context.usuario.FirstOrDefault(u => u.id == 1);
            Assert.AreEqual(usuario.activo, true);
            usuario.activo = false;
            this._testRepository.updateUsuario(usuario);
            Assert.AreEqual(usuario.activo, false);
        }

        [TestMethod]
        public void eliminarUsuario()
        {
            Data.usuario usuario = this._context.usuario.FirstOrDefault(u => u.id == 1);
            Assert.IsNotNull(usuario);
            this._testRepository.deleteUsuario(1);
            usuario = this._context.usuario.FirstOrDefault(u => u.id == 1);
            Assert.IsNull(usuario);
        }

        private void FillMockData()
        {
            this._context.usuario.Add(new usuario() { id = 1, nombre = "Ariel", apellido = "Napoli", activo = true });
            this._context.usuario.Add(new usuario() { id = 2, nombre = "Hernan", apellido = "Alzueta", activo = true });
            this._context.SaveChanges();
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
