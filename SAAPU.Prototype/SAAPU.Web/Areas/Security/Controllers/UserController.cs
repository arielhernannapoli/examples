using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SAAPU.Data.Identity;
using System.Linq;
using SAAPU.Web.Areas.Security.Models;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace SAAPU.Web.Areas.Security.Controllers
{
    [Area("security")]
    public class UserController : Controller
    {
        private readonly UserManager<SAAPUIdentityUser> _userManager;
        private readonly RoleManager<SAAPUIdentityRole> _roleManager;

        public UserController(UserManager<SAAPUIdentityUser> userManager, RoleManager<SAAPUIdentityRole> roleManager)         
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index() 
        {
            var model = _userManager.Users.Select(u=> new UserViewModel() {
                Id = u.Id,
                Name = u.UserName,
                Email = u.Email
            });
            return View(model);
        }

        public IActionResult AddUser()
        {
            var model = new UserViewModel();
            model.Roles = new List<RoleViewModel>();
            _roleManager.Roles.ToList().ForEach(r=> model.Roles.Add(new RoleViewModel() {
                Id = r.Id,
                Name = r.Name,
                Description = r.Description    
            }));
            return View(model);            
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                SAAPUIdentityUser applicationUser = new SAAPUIdentityUser();
                applicationUser.Name = model.Name;
                applicationUser.Email = model.Email;
                applicationUser.UserName = model.Name;
                IdentityResult userRuslt = await _userManager.CreateAsync(applicationUser);
                if (userRuslt.Succeeded)
                {
                    SAAPUIdentityRole applicationRole = await _roleManager.FindByIdAsync(model.RoleId);
                    if (applicationRole != null)
                    {
                        IdentityResult roleResult = await _userManager.AddToRoleAsync(applicationUser, applicationRole.Name);
                        if (roleResult.Succeeded)
                        {
                            return RedirectToAction("Index");
                        }                        
                    }
                }
            }
            return View(model);              
        }

        [HttpGet]
        public async Task<IActionResult> DeleteUser(string id)
        {
            if(!String.IsNullOrEmpty(id))
            {
                SAAPUIdentityUser applicationUser = await _userManager.FindByIdAsync(id);
                if (applicationUser != null)
                {
                    IdentityResult roleRuslt = _userManager.DeleteAsync(applicationUser).Result;
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