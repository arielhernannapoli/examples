using System;
using Microsoft.EntityFrameworkCore;
using Example.Data.Entities;

namespace Example.Data
{
    public class ExampleDbEntities : DbContext
    {
        public DbSet<usuario> usuario {get;set;}

        public ExampleDbEntities(DbContextOptions<ExampleDbEntities> options) : base(options) {

        }

    }
}
