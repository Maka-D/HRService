using HRService.AppServices.LogInAppService;
using HRService.AppServices.RegistrationAppService;
using HRService.AppServices.UserAppService;
using HRService.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HRService.Controllers
{
    public class LogInController :Controller
    {
        private readonly IUser _user;
        private readonly ILogIn _logIn;
        public LogInController(IUser user, ILogIn logIn)
        {
            _user = user;
            _logIn = logIn;
        }
        [HttpGet]
        public IActionResult SignInPage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignInAsync(LogInViewModel model)
        {
            if (ModelState.IsValid)
            {
                var isRegistered =  _user.IsRegistered("", model.Email);
                if (isRegistered)
                {
                    bool signedIn = _logIn.SignInSuccessfully(model);
                    if (signedIn)
                    {
                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name,model.Email)
                        };
                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                        return RedirectToAction("MainPage", "User");
                    }
                    else
                    {
                        TempData["message"] = "Email or Password is incorrect!";
                        return RedirectToAction("SignInPage");
                    }
                    
                }
                else
                {
                    TempData["message"] = "Email or Password is incorrect!";
                    return RedirectToAction("SignInPage");
                }
            }
            return RedirectToAction("SignInPage");
        }

    }
}
