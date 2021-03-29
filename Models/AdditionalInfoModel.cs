using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HRService.Models
{
    public class AdditionalInfoModel 
    {
        public int Id { get; set; }
        public string Position { get; set; }
        public WorkingStatusEnum Status { get; set; }
        public DateTime? DateOfDismissal { get; set; }
        public int MobileNumber { get; set; }

    }
}
