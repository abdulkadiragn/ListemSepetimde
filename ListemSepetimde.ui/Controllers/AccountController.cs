using Entity.POCO;
using ListemSepetimde.ui.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListemSepetimde.ui.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager) //userManager identity'den gelen bir sınıf arka tarafta şifreleme işlemleri gibi şeyleri kendi yapıyor.//singInManager girebilecek kişiler için
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        [HttpGet]
        public async Task<IActionResult> Login(string ReturnUrl)
        {
            TempData["rtnUrl"] = ReturnUrl;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(string userName, string password)
        {
            var sign = await signInManager.PasswordSignInAsync(userName, password, false, false);
            if (sign.Succeeded)
            {
                if (TempData["rtnUrl"] != null)
                {
                    return Redirect(TempData["rtnUrl"].ToString());
                }
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser
                {
                    Email = model.Email,
                    UserName = model.UserName,

                };  
                var identityResult = await userManager.CreateAsync(appUser, model.Password);
                if (!identityResult.Succeeded)
                {
                    foreach (var item in identityResult.Errors)
                    {
                        ModelState.AddModelError("", item.Description); //hata gelirse açıklamaları bas //string boş olması ModelOnly ile form'un en başına hataları bassın
                    }
                    return View(model); //hataları view'e basabilmek için
                }
                else
                {
                    await userManager.AddToRoleAsync(appUser, "UserApp");
                }
            }
            return RedirectToAction("Login"); //başarılı kayıt olan login'e gitsin.
        }
        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index","Home");
        }
    }
}
