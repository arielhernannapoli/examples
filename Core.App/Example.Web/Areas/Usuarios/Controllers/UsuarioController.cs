using Example.Business.Interfaces;
using Example.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Example.Web.Controllers
{
    public class UsuarioController : Controller
    {
        public readonly IUsuarioService _service;

        public UsuarioController(IUsuarioService service) 
        {
            this._service = service;
        }

        public IActionResult Index()
        {
            var usuarios = this._service.getUsuarios();            
            return View(new UsuarioViewModel() {
                Usuarios = usuarios
            });
        }
    }
}