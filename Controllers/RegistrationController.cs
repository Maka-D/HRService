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
    public class RegistrationController :Controller
    {
        private readonly IUser _user;
        private readonly IRegistration _register;
        public RegistrationController(IUser user, IRegistration register)
        {
            _user = user;
            _register = register;
        }
        [HttpPost]
        public async Task<IActionResult> RegistrationAsync(RegisterViewModel registerModel)
        {
            if (ModelState.IsValid)
            {
                var isRegistered =  _user.IsRegistered(registerModel.IdentityNumber, registerModel.Email);
                if (isRegistered)
                {
                    TempData["message"] = "This user already exists, please sign in!";
                    return RedirectToAction("SignInPage", "LogIn");
                }
                else
                {
                    _register.RegisterUser(registerModel);
                    var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, registerModel.Email),
                            new Claim(ClaimTypes.Name, registerModel.IdentityNumber)
                        };
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                    return RedirectToAction("MainPage", "User"); 
                                 
                }
            }
            return RedirectToAction("SignInPage", "LogIn");
        }
    }
}
