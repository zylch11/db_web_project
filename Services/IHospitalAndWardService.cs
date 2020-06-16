using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using db_web_project.Models;

namespace db_web_project.Services
{
    public interface IHospitalAndWardService
    {
        Task<HospitalModel[]> GetIncompleteHospitalsAsync();
        Task<WardModel[]> GetIncompleteWardsAsync();

        Task<bool> AddHospitalAsync(HospitalModel _hospital);
        Task<bool> AddWardAsync(WardModel _ward);

        Task<HospitalModel> FindHospitalAsync(int _hospitalId);
        Task<WardModel> FindWardAsync(int _wardId);

        Task<bool> EditHospitalAsync(HospitalModel _hospital);
        Task<bool> EditWardAsync(WardModel _ward);
    }
}
