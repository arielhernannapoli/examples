using Microsoft.EntityFrameworkCore;
using SAAPU.Data.EF.Entities;

namespace SAAPU.Data.EF
{
    public class SAAPUDbContext : DbContext
    {
        public DbSet<Empresa> Empresa {get;set;}
        
        public SAAPUDbContext(DbContextOptions<SAAPUDbContext> options) : base(options)
        {

        }
    }
}