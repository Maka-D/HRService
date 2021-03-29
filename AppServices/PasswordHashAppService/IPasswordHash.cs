using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRService.AppServices.PasswordHashAppService
{
    public interface IPasswordHash
    {
        string GetHashedPassword(string password);
    }
}
