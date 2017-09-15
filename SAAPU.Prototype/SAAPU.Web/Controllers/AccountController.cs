using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using SAAPU.Data.Identity;
using System.Threading.Tasks;
using SAAPU.Web.Models;
using SAAPU.Web.Ldap;
using System.Collections.Generic;
using System.Security.Claims;
using System;

namespace SAAPU.Web.Controllers
{
    public class AccountController : Controller 
    {
        private readonly SAAPUIdentityDbContext _db;
        private readonly UserManager<SAAPUIdentityUser> _userManager;
        private readonly SignInManager<SAAPUIdentityUser> _signInManager;
        private readonly IAuthenticationService _authService;

        public AccountController(IAuthenticationService authService, UserManager<SAAPUIdentityUser> userManager, SignInManager<SAAPUIdentityUser> signInManager, SAAPUIdentityDbContext db) 
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
            _authService = authService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Login() 
        {
            return View();
        }
    
        public async Task<IActionResult> LogOff() 
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

        [HttpPost]
        public async Task<IActionResult> Register (RegisterViewModel model)
        {
            var user = new SAAPUIdentityUser { UserName = model.Email };
            IdentityResult result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }    

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: true, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index","Home");
            }
            else
            {
                return View();
            }
         
            /*
            if (ModelState.IsValid)
            {
                try
                {
                    var user = _authService.Login(model.Email, model.Password);
                    if (null != user)
                    {
                        var userClaims = new List<Claim>
                        {
                            new Claim("displayName", user.DisplayName),
                            new Claim("username", user.Username)
                        };
                        if (user.IsAdmin)
                        {
                            userClaims.Add(new Claim(ClaimTypes.Role, "Admins"));
                        }
                        var principal = new ClaimsPrincipal(new ClaimsIdentity(userClaims, _authService.GetType().Name));
                        await Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.SignInAsync(this.HttpContext, "app", principal);
                        return Redirect("/");
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            return View(model);    
            */        
        }            
    }
}