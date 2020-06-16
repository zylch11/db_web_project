using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using db_web_project.Services;
using db_web_project.Models;

namespace db_web_project.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IDoctorService _doctorService;
        Doctor doctor { get; set; }

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        public async Task<IActionResult> Index()
        {
            var doctors = await _doctorService.GetIncompleteDoctorsAsync();
            var model = new DoctorViewModel()
            {
                Doctors = doctors
            };

            return View(model);
        }

        public IActionResult AddDoctor()
        {

            return View();
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(Doctor _doctor)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            var successful = await _doctorService.AddDoctorAsync(_doctor);
            if (!successful)
            {
                return BadRequest("Could not Add Doctor");
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(Doctor _doctor)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            var successful = await _doctorService.EditDoctorAsync(_doctor);
            if (!successful)
            {
                return BadRequest("Could not Edit Doctor");
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> EditDoctor(Guid Id)
        {
            doctor = await _doctorService.FindDoctorAsync(Id);
            return View(doctor);
        }

    }
}
