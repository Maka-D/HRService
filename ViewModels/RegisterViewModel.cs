using HRService.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HRService.ViewModels
{
    public class RegisterViewModel
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
        [MinLength(6, ErrorMessage = "Minimum length of password must be 6")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [MinLength(6, ErrorMessage ="Minimum length of  password must be 6")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Password and Repeat Password fields must match.")]
        public string RepeatPassword { get; set; }
    }
}
