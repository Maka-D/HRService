using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HRService.Models
{
    public class EmployeeInfoModel
    {
        public int Id { get; set; }
        public string IdentityNumber { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public GenderEnum? Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsRegistered { get; set; }
        public int? AdditionalInfoId { get; set; }
        [ForeignKey("AdditionalInfoId")]
        public AdditionalInfoModel AdditionalInfo { get; set; }
    }
}
