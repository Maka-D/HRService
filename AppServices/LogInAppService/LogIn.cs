using Abp.Domain.Uow;
using HRService.AppServices.PasswordHashAppService;
using HRService.EntityFramework;
using HRService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRService.AppServices.LogInAppService
{
    public class LogIn : ILogIn
    {
        private readonly AppDbContext _regRepository;
        private readonly IPasswordHash _hashPassword;
        public LogIn(AppDbContext regRepository, IPasswordHash hashPassword)
        {
            _regRepository = regRepository;
            _hashPassword = hashPassword;
        }
        [UnitOfWork]
        public bool SignInSuccessfully(LogInViewModel model)
        {
            var user = _regRepository.EmploeesInfo.Where(x => x.Email == model.Email).FirstOrDefault();
            var hashedPass = _hashPassword.GetHashedPassword(model.Password);
            if(user.Password == hashedPass)
            {
                return true;
            }
            return false;
        }
    }
}
