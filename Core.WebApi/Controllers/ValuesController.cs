using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace Core.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly TestDbContext _context;

        public ValuesController(TestDbContext context) {
            this._context = context;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<usuario> Get()
        {
            return this._context.usuario.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public usuario Get(int id)
        {
            return this._context.usuario.FirstOrDefault(u=>u.id.Equals(id));
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]usuario value)
        {
            this._context.usuario.Add(value);
            this._context.SaveChanges();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]usuario value)
        {
            usuario usuario = this._context.usuario.FirstOrDefault(u=>u.id.Equals(id));
            usuario.nombre = value.nombre;
            usuario.apellido = value.apellido;
            usuario.usuario1 = value.usuario1;
            usuario.activo = value.activo;
            this._context.Attach(usuario);
            this._context.SaveChanges();        
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            usuario usuario = this._context.usuario.FirstOrDefault(u=>u.id.Equals(id));
            this._context.usuario.Remove(usuario);
            this._context.SaveChanges();
        }
    }
}
