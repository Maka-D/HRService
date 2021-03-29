using HRService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRService.AppServices.UserAppService
{
    public interface IUser
    {
        bool IsRegistered(string IdentityNumber, string Email);
        List<EmployeeListViewModel> PrintAllEmployeesNames();
        void AddEmployee(AddEmployeeViewModel model);
        bool ExistsEmployee(int Id);
        void DeleteEmployee(int Id);
        AddEmployeeViewModel GetEmployeeInfo(int Id);
        void UpdateEmployeeInfo(AddEmployeeViewModel model);
        List<EmployeeListViewModel> PrintSearchedEmployees(string searchContent);
    }
}
