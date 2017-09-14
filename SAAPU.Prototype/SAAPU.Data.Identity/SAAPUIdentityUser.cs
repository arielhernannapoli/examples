using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace SAAPU.Data.Identity
{
    public class SAAPUIdentityUser : IdentityUser
    {
        public string Name { get; set; }
    }
}