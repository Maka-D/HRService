using HRService.AppServices.UserAppService;
using HRService.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRService.Controllers
{
    public class UserController :Controller
    {
        private readonly IUser _user;
        public UserController(IUser user)
        {
            _user = user;
        }
        [HttpGet]
        [Authorize]
        public IActionResult MainPage(string searchContent)
        {
            var employeeList = new List<EmployeeListViewModel>();
            if (String.IsNullOrEmpty(searchContent)){
                employeeList = _user.PrintAllEmployeesNames();
            }
            else
            {
                employeeList = _user.PrintSearchedEmployees(searchContent);
                if(employeeList.Count == 0)
                {
                    TempData["info"] = "Could't find matching user!";
                }
            }
            
            return View(employeeList);
        }
        [HttpGet]
        public IActionResult ResetSearch()
        {
            return RedirectToAction("MainPage");
        }
        [HttpGet]
        [Authorize]
        public IActionResult AddEmployeePage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddEmployee(AddEmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var isRegistered = _user.IsRegistered(model.IdentityNumber, model.Email);
                if (isRegistered)
                {
                    TempData["UserMessage"] = "This user already exists";
                    return RedirectToAction("AddEmployeePage");
                }
                else
                {
                    _user.AddEmployee(model); 
                    TempData["UserMessage"] = "Successfully Added";
                    return RedirectToAction("AddEmployeePage");
         
                }
            }
            return RedirectToAction("AddEmployeePage");
        }
        [HttpGet]
        public IActionResult GoToMainPage()
        {
            return RedirectToAction("MainPage");
        }
        [HttpDelete]
        public JsonResult DeleteEmployee(int Id)
        {
            if (_user.ExistsEmployee(Id))
            {
                _user.DeleteEmployee(Id);
            }
            return Json(new { redirectUrl = Url.Action("MainPage"), isRedirect = true });
        }
        
        [HttpPost]
        public IActionResult EditEmployee(int employeeId)
        {
            if (_user.ExistsEmployee(employeeId))
            {
                var employee = _user.GetEmployeeInfo(employeeId);
                return RedirectToAction("EditEmployeePage", employee);
            }
            return RedirectToAction("MainPage");

        }
        [HttpGet]
        [Authorize]
        public IActionResult EditEmployeePage(AddEmployeeViewModel model)
        {
            return View(model);
        }
        [HttpPost]
        public IActionResult SaveEditedInfo(AddEmployeeViewModel model)
        {
            _user.UpdateEmployeeInfo(model);
            return RedirectToAction("MainPage");
        }
        [HttpGet]
        public async Task<IActionResult> LogOutAsync()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("SignInPage", "LogIn");
        }
    }
}
