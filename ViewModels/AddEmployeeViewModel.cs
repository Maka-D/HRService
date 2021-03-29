using HRService.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HRService.ViewModels
{
    public class AddEmployeeViewModel
    {
        [Required]
        [RegularExpression("^[0-9]{11}$", ErrorMessage = "The length of Identity Number must be 11 and be numeric")]
        public string IdentityNumber { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string SecondName { get; set; }
        public GenderEnum? Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public string Position { get; set; }
        [Required]
        public WorkingStatusEnum Status { get; set; }
        public DateTime? DateOfDismissal { get; set; }
        public int MobileNumber { get; set; }
        public int EmployeeId { get; set; }
    }
}
