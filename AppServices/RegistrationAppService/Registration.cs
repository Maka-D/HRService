using Abp.Domain.Uow;
using HRService.AppServices.PasswordHashAppService;
using HRService.EntityFramework;
using HRService.Models;
using HRService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRService.AppServices.RegistrationAppService
{
    public class Registration : IRegistration
    {
        private readonly AppDbContext _regRepository;
        private readonly IPasswordHash _passwordHash;
        public Registration(AppDbContext regRepository, IPasswordHash passwordHash)
        {
            _regRepository = regRepository;
            _passwordHash = passwordHash;
        }
        [UnitOfWork]
        public void RegisterUser(RegisterViewModel model)
        {
            var employee = new EmployeeInfoModel();            
            employee.IdentityNumber = model.IdentityNumber;
            employee.FirstName = model.FirstName;
            employee.SecondName = model.SecondName;
            employee.Email = model.Email;
            employee.Gender = model.Gender;
            employee.BirthDate = model.BirthDate;
            employee.Password = _passwordHash.GetHashedPassword(model.Password);
            employee.IsRegistered = true;
            _regRepository.EmploeesInfo.Add(employee);
            _regRepository.SaveChanges();
        }
    }
}
