using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using db_web_project.Models;

namespace db_web_project.Services
{
    public interface IPatientService
    {
        Task<PatientModel[]> GetIncompletePatientsAsync();

        Task<bool> AddPatientAsync(PatientModel _patient);

        Task<PatientModel> FindPatientAsync(Guid id);

        Task<bool> EditPatientAsync(PatientModel _patient);
    }
}
