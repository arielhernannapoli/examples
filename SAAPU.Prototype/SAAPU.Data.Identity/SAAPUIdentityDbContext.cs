using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SAAPU.Data.Identity
{
    public class SAAPUIdentityDbContext : IdentityDbContext<SAAPUIdentityUser, SAAPUIdentityRole, int>
    {
        public SAAPUIdentityDbContext(DbContextOptions<SAAPUIdentityDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            /*
            modelBuilder.Entity<SAAPUIdentityUser>().ToTable("Usuario");
            modelBuilder.Entity<SAAPUIdentityRole>().ToTable("Rol");
            modelBuilder.Entity<SAAPUIdentityUserRole>().ToTable("UsuarioRoles");
            modelBuilder.Entity<SAAPUIdentityUserLogin>().ToTable("UsuarioLogin");
            modelBuilder.Entity<SAAPUIdentityUserClaim>().ToTable("UsuarioClaim");
            */
        }
    }
}