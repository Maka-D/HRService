using Abp.Domain.Uow;
using HRService.EntityFramework;
using HRService.Models;
using HRService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRService.AppServices.UserAppService
{
    public class User : IUser
    {
        private readonly AppDbContext _regRepository;
        public User(AppDbContext regRepository)
        {
            _regRepository = regRepository;
        }
        [UnitOfWork]
        public bool IsRegistered(string IdentityNumber, string Email)
        {
            var user = _regRepository.EmploeesInfo.Where(x => x.IdentityNumber == IdentityNumber || x.Email == Email).FirstOrDefault();
            if (user != null && user.IsRegistered)
            {
                return true;
            }
            return false;
        }
        [UnitOfWork]
        public List<EmployeeListViewModel> PrintAllEmployeesNames()
        {
            var employeeList = new List<EmployeeListViewModel>();
            var employees = _regRepository.EmploeesInfo.OrderBy(x => x.FirstName);
            foreach(var item in employees)
            {
                var employee = new EmployeeListViewModel();
                employee.Id = item.Id;
                employee.FirstName = item.FirstName;
                employee.SecondName = item.SecondName;
                employeeList.Add(employee);
            }
            return employeeList;
        }
        [UnitOfWork]
        public void AddEmployee(AddEmployeeViewModel model)
        {
            var employee = new EmployeeInfoModel();
            var additionalInfo = new AdditionalInfoModel();
            employee.IdentityNumber = model.IdentityNumber;
            employee.FirstName = model.FirstName;            
            employee.SecondName = model.SecondName;
            employee.Email = model.Email;
            employee.Gender = model.Gender;
            employee.BirthDate = model.BirthDate;
            additionalInfo.Position = model.Position;
            additionalInfo.Status = model.Status;
            additionalInfo.MobileNumber = model.MobileNumber;
            additionalInfo.DateOfDismissal = model.DateOfDismissal;
            employee.AdditionalInfo = additionalInfo;
            _regRepository.EmploeesInfo.Add(employee);
            _regRepository.EmployeesAdditionalInfos.Add(additionalInfo);
            _regRepository.SaveChanges();
        }
        [UnitOfWork]
        public void DeleteEmployee(int Id)
        {
            var user = _regRepository.EmploeesInfo.Where(x => x.Id == Id).FirstOrDefault();
            if(user.AdditionalInfoId != null)
            {
                var additionalInfo = _regRepository.EmployeesAdditionalInfos.Where(x => x.Id == user.AdditionalInfoId).FirstOrDefault();
                _regRepository.EmployeesAdditionalInfos.Remove(additionalInfo);
                
            }
            _regRepository.EmploeesInfo.Remove(user);          
            _regRepository.SaveChanges();
        }
        [UnitOfWork]
        public bool ExistsEmployee(int Id)
        {
            var exists = _regRepository.EmploeesInfo.Any(x => x.Id == Id);
            if (exists)
            {
                return true;
            }
            return false;

        }
        [UnitOfWork]
        public AddEmployeeViewModel GetEmployeeInfo(int Id)
        {
            var employee = _regRepository.EmploeesInfo.Where(x => x.Id == Id).FirstOrDefault();
            var employeeInfo = new AddEmployeeViewModel();
            if (employee != null)
            {
                employeeInfo.EmployeeId = employee.Id;
                employeeInfo.IdentityNumber = employee.IdentityNumber;
                employeeInfo.SecondName = employee.SecondName;
                employeeInfo.FirstName = employee.FirstName;
                employeeInfo.Email = employee.Email;
                employeeInfo.BirthDate = employee.BirthDate;
                employeeInfo.Gender = employee.Gender;
                if(employee.AdditionalInfoId != null)
                {
                    employee.AdditionalInfo = _regRepository.EmployeesAdditionalInfos.Where(x => x.Id == employee.AdditionalInfoId).FirstOrDefault();
                    employeeInfo.Status = employee.AdditionalInfo.Status;
                    employeeInfo.Position = employee.AdditionalInfo.Position;
                    employeeInfo.MobileNumber = employee.AdditionalInfo.MobileNumber;
                    employeeInfo.DateOfDismissal = employee.AdditionalInfo.DateOfDismissal;
                }
                          
            }
            return employeeInfo;
        }
        [UnitOfWork]
        public void UpdateEmployeeInfo(AddEmployeeViewModel model)
        {
            var employee = _regRepository.EmploeesInfo.Where(x => x.Id == model.EmployeeId).FirstOrDefault();
            employee.IdentityNumber = model.IdentityNumber;
            employee.FirstName = model.FirstName;
            employee.SecondName = model.SecondName;
            employee.Email = model.Email;
            employee.BirthDate = model.BirthDate;
            employee.Gender = model.Gender;
            if(employee.AdditionalInfoId == null)
            {
                var additionalInfo = new AdditionalInfoModel();
                additionalInfo.Position = model.Position;
                additionalInfo.Status = model.Status;
                additionalInfo.MobileNumber = model.MobileNumber;
                additionalInfo.DateOfDismissal = model.DateOfDismissal;
                employee.AdditionalInfo = additionalInfo;
            }
            else
            {
                employee.AdditionalInfo = _regRepository.EmployeesAdditionalInfos.Where(x => x.Id == employee.AdditionalInfoId).FirstOrDefault();
                employee.AdditionalInfo.Position = model.Position;
                employee.AdditionalInfo.Status = model.Status;
                employee.AdditionalInfo.MobileNumber = model.MobileNumber;
                employee.AdditionalInfo.DateOfDismissal = model.DateOfDismissal;
            }          
            _regRepository.SaveChanges();
        }
        [UnitOfWork]
        public List<EmployeeListViewModel> PrintSearchedEmployees(string searchContent)
        {
            var employeeList = new List<EmployeeListViewModel>();
            var employeesInfoContainer = _regRepository.EmploeesInfo;
            var searchText = searchContent.Trim();
            if (searchText.Contains(' '))
            {
                var searchContentValues = searchText.Split(' ');
                foreach (var item in searchContentValues)
                {
                    
                    if (employeesInfoContainer.Any(x => x.FirstName.Contains(item) || x.SecondName.Contains(item)))
                    {
                        var employeesInfoList = employeesInfoContainer.Where(x => x.FirstName.Contains(item) || x.SecondName.Contains(item)).ToList();
                        foreach (var user in employeesInfoList)
                        {
    
                            if (employeeList.Any(x => x.Id == user.Id))
                            {
                                break;                              
                            }
                            else
                            {
                                var employee = new EmployeeListViewModel();
                                employee.Id = user.Id;
                                employee.FirstName = user.FirstName;
                                employee.SecondName = user.SecondName;
                                employeeList.Add(employee);
                            }
                        }
                        
                       
                    }
                }
            }
            else
            {
                if (employeesInfoContainer.Any(x => x.FirstName.Contains(searchText) || x.SecondName.Contains(searchText)))
                {
                    var employeesInfoList = employeesInfoContainer.Where(x => x.FirstName.Contains(searchText) || x.SecondName.Contains(searchText)).ToList();
                    foreach (var user in employeesInfoList)
                    {
                        var employee = new EmployeeListViewModel();
                        employee.Id = user.Id;
                        employee.FirstName = user.FirstName;
                        employee.SecondName = user.SecondName;
                        employeeList.Add(employee);
                    }
                }
            }
            return employeeList;
        }
    }
}
