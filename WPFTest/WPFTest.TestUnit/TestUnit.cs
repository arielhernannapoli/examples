using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WPFTest.Data;
using WPFTest.Data.Interfaces;
using WPFTest.Servicios;
using WPFTest.Servicios.Interfaces;
using AutoMapper;

namespace WPFTest.TestUnit
{
    [TestClass]
    public class TestUnit
    {
        private ITestService _testService;

        [TestInitialize]
        public void InitTest()
        {
            this.ConfigurarMappings();
            this._testService = new TestService();
        }

        [TestMethod]
        public void obtenerUsuarios()
        {
            var usuarios = this._testService.getUsuarios();
            Assert.AreEqual(usuarios.Count, 1);
        }

        [TestMethod]
        public void insertarUsuario()
        {
            int cantidadPre = this._testService.getUsuarios().Count;
            var usuario = new Model.Usuario()
            {
                Id = 2,
                Nombre = "Hernan",
                Apellido = "Alzueta",
                NombreUsuario = "halzueta",              
                Activo = true
            };
            this._testService.insertUsuario(usuario);
            int cantidadPost = this._testService.getUsuarios().Count;
            Assert.AreEqual(cantidadPre+1, cantidadPost);
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
