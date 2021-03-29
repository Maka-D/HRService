using HRService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRService.AppServices.RegistrationAppService
{
    public interface IRegistration
    {
        void RegisterUser(RegisterViewModel model);
    }
}
