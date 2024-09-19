using Edu4TechBankEL.IdentityModels;
using Edu4TechBankWebUI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Edu4TechBankWebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;

        public AccountController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager) //Dependency Intection
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string? email, string? password)
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Girişi düzgün yapınız");
                    return View(model);
                }
                //isim
                var sameUserName = _userManager.FindByNameAsync(model.Username).Result;

                if (sameUserName != null)
                {
                    ModelState.AddModelError("", $"{model.Username} isminde bir kullanıcı zaten sistemde var!");
                    return View(model);
                }
                //email
                var sameEmail = _userManager.FindByEmailAsync(model.Email).Result;

                if (sameEmail != null)
                {
                    ModelState.AddModelError("", $"{model.Email} bu email zaten sistemde var!");
                    return View(model);
                }
                //kayıt
                AppUser user = new AppUser()
                {
                    Name= model.Name,
                    Surname = model.Surname,
                    Email = model.Email,
                    UserName = model.Username,
                    Gender = model.Gender,
                    BirthDate = model.Birthdate,
                    EmailConfirmed=false
                };
                var result = _userManager.CreateAsync(user, model.Password).Result;
                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", "Kayıt olunamadı!");
                    return View(model);
                }

                return RedirectToAction("Address");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Bir hata oluştu");
                return View();
            }
        }
    }
}
