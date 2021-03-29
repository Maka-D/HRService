using HRService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRService.AppServices.LogInAppService
{
    public interface ILogIn
    {
        bool SignInSuccessfully(LogInViewModel model);
    }
}
