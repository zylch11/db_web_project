using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using db_web_project.Models;
using db_web_project.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace db_web_project.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly ApplicationDbContext _context;
        [BindProperty]
        public Doctor doctor { get; set; }

        public DoctorService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Doctor[]> GetIncompleteDoctorsAsync()
        {
            return await _context.Doctors.ToArrayAsync();
        }

        public async Task<bool> AddDoctorAsync(Doctor _doctor)
        {
            _doctor.Id = Guid.NewGuid();

            _context.Doctors.Add(_doctor);

            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }

        public async Task<Doctor> FindDoctorAsync(Guid Id)
        {
            doctor = await _context.Doctors.FindAsync(Id);
            return doctor;
        }

        public async Task<bool> EditDoctorAsync(Doctor _doctor)
        {
            var doctor = await _context.Doctors.FindAsync(_doctor.Id);
            doctor.Name = _doctor.Name;
            doctor.Qualification = _doctor.Qualification;
            doctor.Age = _doctor.Age;
            doctor.CNIC = _doctor.CNIC;
            doctor.HospitalId = _doctor.HospitalId;
            doctor.Role = _doctor.Role;

            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }
    }
}
