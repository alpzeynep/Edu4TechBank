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
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Girişleri düzgün yapınız");
                    return View(model);
                }

                //// kullanıcı adı
                //var sameUserName = _userManager.FindByNameAsync(model.Username).Result;

                //if (sameUserName != null)
                //{
                //    ModelState.AddModelError("", $"{model.Username} adlı kulanıcı zaten var.");
                //    return View(model);
                //}
                ////email
                //var sameEmail = _userManager.FindByEmailAsync(model.Email).Result;

                //if (sameEmail != null)
                //{
                //    ModelState.AddModelError("", $"{model.Email} adlı email zaten var.");
                //    return View(model);
                //}
                AppUser user = new AppUser()
                {
                    Name = model.Name,
                    Surname = model.Surname,
                    Email = model.Email,
                    UserName = model.Username,
                    Gender = model.Gender,
                    BirthDate = model.Birthdate,
                    EmailConfirmed = false
                };

                var result = _userManager.CreateAsync(user, model.Password).Result;
                if (!result.Succeeded)
                {
                    string hataMesaji = string.Empty;
                    if (result.Errors != null)
                    {
                        foreach (var item in result.Errors)
                        {
                            hataMesaji += $"{item.Description}\n";
                        }
                    }
                    ModelState.AddModelError("", $"Kayıt başarısızdır! {hataMesaji}");
                    return View(model);

                }
               var roleResult= _userManager.AddToRoleAsync(user, "Musteri").Result;
                if (!roleResult.Succeeded)
                {

                }



                return RedirectToAction("Address", "Home");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }
    }
} 
