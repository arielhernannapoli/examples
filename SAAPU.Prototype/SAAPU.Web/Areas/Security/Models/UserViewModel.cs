using System.Collections.Generic;

namespace SAAPU.Web.Areas.Security.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RoleId { get; set; }
        public List<RoleViewModel> Roles { get; set; }

        public UserViewModel() 
        {
            this.Roles = new List<RoleViewModel>();
        }
    }
}