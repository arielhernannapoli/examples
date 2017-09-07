using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Model {
    public class TestDbContext : DbContext {

        public DbSet<usuario> usuario {get;set;}

        public TestDbContext(DbContextOptions<TestDbContext> options) : base(options) {

        }
        
    }

    public class usuario {
        public int id {get;set;}
        public string nombre {get;set;}
        public string apellido {get;set;}
        
        [Column("usuario")]
        public string usuario1 {get;set;}
        public bool activo {get;set;}
    }
}