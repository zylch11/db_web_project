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
    public class PatientService : IPatientService
    {
        private readonly ApplicationDbContext _context;
        [BindProperty]
        public PatientModel patient { get; set; }

        public PatientService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PatientModel[]> GetIncompletePatientsAsync()
        {
            return await _context.Patients.ToArrayAsync();
        }

        public async Task<bool> AddPatientAsync(PatientModel _patient)
        {
            _patient.Id = Guid.NewGuid();

            _context.Patients.Add(_patient);

            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }

        public async Task<PatientModel> FindPatientAsync(Guid id)
        {
            patient = await _context.Patients.FindAsync(id);
            return patient;
        }

        public async Task<bool> EditPatientAsync(PatientModel _patient)
        {
            var patient = await _context.Patients.FindAsync(_patient.Id);
            patient.Name = _patient.Name;
            patient.HospitalId = _patient.HospitalId;
            patient.Gender = _patient.Gender;
            patient.CNIC = _patient.CNIC;
            patient.Age = _patient.Age;
            patient.Address = _patient.Address;
            patient.WardName = _patient.WardName;

            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }
    }
}
