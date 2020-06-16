using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using db_web_project.Services;
using db_web_project.Models;

namespace db_web_project.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientService _patientService;
        PatientModel patient { get; set; }

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        public async Task<IActionResult> Index()
        {
            var patients = await _patientService.GetIncompletePatientsAsync();
            var model = new PatientViewModel()
            {
                Patients = patients
            };

            return View(model);
        }

        public IActionResult AddPatient()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(PatientModel _patient)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            var successful = await _patientService.AddPatientAsync(_patient);
            if (!successful)
            {
                return BadRequest("Could not Add Patient");
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(PatientModel _patient)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            var successful = await _patientService.EditPatientAsync(_patient);
            if (!successful)
            {
                return BadRequest("Could not Edit Patient");
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> EditPatient(Guid Id)
        {
            patient = await _patientService.FindPatientAsync(Id);
            return View(patient);
        }
    }
}
