using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using db_web_project.Models;

namespace db_web_project.Services
{
    public interface IDoctorService
    {
        Task<Doctor[]> GetIncompleteDoctorsAsync();

        Task<bool> AddDoctorAsync(Doctor _doctor);

        Task<Doctor> FindDoctorAsync(Guid id);

        Task<bool> EditDoctorAsync(Doctor _doctor);
    }
}
