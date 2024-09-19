using Edu4TechBankEL.AllEnums;
using Edu4TechBankEL.IdentityModels;
using Edu4TechBankWebUI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Edu4TechBankWebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string? emailorUsername, string? password)
        {
            try
            {
                if (string.IsNullOrEmpty(emailorUsername) || string.IsNullOrEmpty(password))
                {
                    ModelState.AddModelError("", "Email ya da kullanıcı adı ve şifre alanlarını giriniz!");
                    return View("Login");
                }
                //emailorUsername gelen parametreye ait kullanııc var mı?
                var user = _userManager.FindByEmailAsync(emailorUsername).Result;
                if (user == null)
                {
                    user = _userManager.FindByNameAsync(emailorUsername).Result;
                }
                if (user == null)
                {
                    ModelState.AddModelError("", "Lütfen sisteme kayıtlı email ya da kullanıcı adınızla giriş yapınız! ");
                    return View("Login");
                }

                //Role bakmamız
                #region Yontem 2
                //şifre kontrolü
                var signInResult = _signInManager.PasswordSignInAsync(user, password, true, false).Result;
                if (!signInResult.Succeeded)
                {
                    ModelState.AddModelError("", "Email / kullanıcı adı ve şifrenizi doğru girdiğinize emin olunuz!");
                    return View("Login");
                }

                else if (_userManager.IsInRoleAsync(user, Roles.BANKACLSN.ToString()).Result)
                {
                    return RedirectToAction("Index", "Admin");
                }
                else if (_userManager.IsInRoleAsync(user, Roles.MUSTERI.ToString()).Result)
                {
                    return RedirectToAction("Hesaplarim", "Account");
                }
                //assignment : Eğer bu kişi sistemde deleted olmuşsa rolü deleted şeklindedir ozaman giriş yapmaya çalıştığında farklı bir sayfaya yönlendirilip o sayfada "Beni tekrar AKtif yap" butonu olsun ve o butona tıklarsa rolü deleted --> member

                #endregion


                return View("Login");

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Beklenmedik Hata");
                return View();
            }


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


    
    public IActionResult Hesaplarim()
    {
        return View();
    }




}
} 
