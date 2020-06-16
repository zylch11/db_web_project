using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace db_web_project.Models
{
    public class HospitalAndWardViewModel
    {
        public HospitalModel[] Hospitals { get; set; }
        public WardModel[] Wards { get; set; }
    }
}
