using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SAAPU.Data.Identity
{
    public class SAAPUIdentityDbContext : IdentityDbContext<SAAPUIdentityUser, SAAPUIdentityRole, int>
    {
        public SAAPUIdentityDbContext(DbContextOptions<SAAPUIdentityDbContext> options) : base(options)
        {

        }
    }
}