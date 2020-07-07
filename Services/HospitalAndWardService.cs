﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using db_web_project.Data;
using db_web_project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace db_web_project.Services
{
    public class HospitalAndWardService : IHospitalAndWardService
    {
        private readonly ApplicationDbContext _context;
        [BindProperty]
        public HospitalModel hospital { get; set; }
        public WardModel ward { get; set; }

        public HospitalAndWardService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<HospitalModel[]> GetIncompleteHospitalsAsync()
        {
            return await _context.Hospitals.ToArrayAsync();
        }

        public async Task<WardModel[]> GetIncompleteWardsAsync()
        {
            return await _context.Wards.ToArrayAsync();
        }

        public async Task<bool> AddHospitalAsync(HospitalModel _hospital)
        {
            _context.Hospitals.Add(_hospital);

            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }

        public async Task<bool> AddWardAsync(WardModel _ward)
        {
            _context.Wards.Add(_ward);

            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }

        public async Task<HospitalModel> FindHospitalAsync(int _hospitalId)
        {
            hospital = await _context.Hospitals.FindAsync(_hospitalId);
            return hospital;
        }

        public async Task<bool> EditHospitalAsync(HospitalModel _hospital)
        {
            //var hospital = await _context.Hospitals.FindAsync(_hospital.HospitalId);
            var Id = _hospital.HospitalId;
            var hospital = await FindHospitalAsync(Id);
            hospital.HospitalName = _hospital.HospitalName;
            hospital.HospitalAddress = _hospital.HospitalAddress;

            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }

        public async Task<WardModel> FindWardAsync(int _wardId)
        {
            ward = await _context.Wards.FindAsync(_wardId);
            return ward;
        }

        public async Task<bool> EditWardAsync(WardModel _ward)
        {
            var ward = await _context.Wards.FindAsync(_ward.WardId);
            ward.WardId = _ward.WardId;
            ward.WardCapacity = _ward.WardCapacity;
            ward.WardCategory = ward.WardCategory;

            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }
    }
}
