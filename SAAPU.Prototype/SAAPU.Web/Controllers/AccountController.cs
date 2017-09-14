using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using SAAPU.Data.Identity;
using System.Threading.Tasks;
using SAAPU.Web.Models;

namespace SAAPU.Web.Controllers
{
    public class AccountController : Controller 
    {
        private readonly SAAPUIdentityDbContext _db;
        private readonly UserManager<SAAPUIdentityUser> _userManager;
        private readonly SignInManager<SAAPUIdentityUser> _signInManager;

        public  AccountController(UserManager<SAAPUIdentityUser> userManager, SignInManager<SAAPUIdentityUser> signInManager, SAAPUIdentityDbContext db) 
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
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
            return RedirectToAction("Index");
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
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }            
    }
}