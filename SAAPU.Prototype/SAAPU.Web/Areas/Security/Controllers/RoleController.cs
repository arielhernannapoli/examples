using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SAAPU.Data.Identity;
using System.Linq;
using SAAPU.Web.Areas.Security.Models;
using System.Threading.Tasks;
using System;

namespace SAAPU.Web.Areas.Security.Controllers
{
    [Area("security")]
    public class RoleController : Controller
    {
        private readonly RoleManager<SAAPUIdentityRole> _roleManager;
        
        public RoleController(RoleManager<SAAPUIdentityRole> roleManager) 
        {
            _roleManager = roleManager;
        }

        public IActionResult Index() 
        {
            var model = _roleManager.Roles.Select(r=> new RoleViewModel() {
                Id = r.Id,
                Name = r.Name,
                Description = r.Description
            });
            return View(model);
        }

        public IActionResult AddRole()
        {
            var model = new RoleViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(RoleViewModel model) 
        {
            if (ModelState.IsValid)
            {
                SAAPUIdentityRole applicationRole = new SAAPUIdentityRole
                {                   
                    CreatedDate = DateTime.UtcNow                   
                };
                applicationRole.Name = model.Name;
                applicationRole.Description = model.Description;
                applicationRole.IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                IdentityResult roleRuslt = await _roleManager.CreateAsync(applicationRole);
                if (roleRuslt.Succeeded)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(model);            
        }

        [HttpGet]
        public async Task<IActionResult> DeleteRole(string id)
        {
            if(!String.IsNullOrEmpty(id))
            {
                SAAPUIdentityRole applicationRole = await _roleManager.FindByIdAsync(id);
                if (applicationRole != null)
                {
                    IdentityResult roleRuslt = _roleManager.DeleteAsync(applicationRole).Result;
                    if (roleRuslt.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            return View();            
        }
    }

}