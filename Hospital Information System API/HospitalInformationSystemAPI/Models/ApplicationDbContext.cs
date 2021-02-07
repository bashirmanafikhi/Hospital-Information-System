using System.Collections.Generic;
using HospitalInformationSystemAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalInformationSystemAPI.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }




        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=HospitalDB.db");
    }

}
