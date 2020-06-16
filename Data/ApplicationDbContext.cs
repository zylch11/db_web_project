using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using db_web_project.Models;

namespace db_web_project.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<PatientModel> Patients { get; set; }

        public DbSet<HospitalModel> Hospitals { get; set; }

        public DbSet<WardModel> Wards { get; set; }
    }
}
