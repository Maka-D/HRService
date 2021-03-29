using HRService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRService.EntityFramework
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<EmployeeInfoModel> EmploeesInfo { get; set; }
        public DbSet<AdditionalInfoModel> EmployeesAdditionalInfos { get; set; }
    }
}
