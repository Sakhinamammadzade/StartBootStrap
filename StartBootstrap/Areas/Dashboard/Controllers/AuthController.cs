using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StartBootstrap.Areas.DTOs;
using StartBootstrap.Models;

namespace StartBootstrap.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class AuthController : Controller
    {
        private readonly UserManager<M001Users> _userManager;
        private readonly SignInManager<M001Users> _signInManager;

        public AuthController(UserManager<M001Users> userManager, SignInManager<M001Users> signInManager)
        {
             _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
       public async Task<IActionResult>Register(RegisterDto model)
        {
            M001Users user = new()
            {
                UserName=model.Email,
                FirstName=model.FirstName,
                LastName=model.LastName,
                Email=model.Email,
                FullName=model.FirstName + " " + model.LastName,    

            };
            IdentityResult result=await _userManager.CreateAsync(user,model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Login");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }


        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");

        }
    }
}
