using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using db_web_project.Services;
using db_web_project.Models;

namespace db_web_project.Controllers
{
    public class HospitalAndWardController : Controller
    {
        private readonly IHospitalAndWardService _hospitalAndWardService;
        HospitalModel hospital { get; set; }

        public HospitalAndWardController(IHospitalAndWardService hospitalAndWardService)
        {
            _hospitalAndWardService = hospitalAndWardService;
        }

        public async Task<IActionResult> Index()
        {
            var hospitals = await _hospitalAndWardService.GetIncompleteHospitalsAsync();
            var wards = await _hospitalAndWardService.GetIncompleteWardsAsync();

            var model = new HospitalAndWardViewModel
            {
                Hospitals = hospitals
            };
            model.Wards = wards;

            return View(model);
        }

        public IActionResult AddHospital()
        {
            return View();
        }
        
        public IActionResult AddWard()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(HospitalModel _hospital)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            var successful = await _hospitalAndWardService.AddHospitalAsync(_hospital);
            if (!successful)
            {
                return BadRequest("Could not Add Hospital");
            }

            return RedirectToAction("Index");
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddW(WardModel _ward)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            var successful = await _hospitalAndWardService.AddWardAsync(_ward);
            if (!successful)
            {
                return BadRequest("Could not Add Ward");
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> EditHosp(HospitalModel _hospital)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            var successful = await _hospitalAndWardService.EditHospitalAsync(_hospital);
            if (!successful)
            {
                return BadRequest("Could not Edit Hospital");
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> EditHospital(int _hospitalId)
        {
            hospital = await _hospitalAndWardService.FindHospitalAsync(_hospitalId);
            return View(hospital);
        }

        public async Task<IActionResult> EditW(WardModel _ward)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            var successful = await _hospitalAndWardService.EditWardAsync(_ward);
            if (!successful)
            {
                return BadRequest("Could not Edit Ward");
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> EditWard(int _wardId)
        {
            var ward = await _hospitalAndWardService.FindWardAsync(_wardId);
            return View(ward);
        }

        
    }
}
