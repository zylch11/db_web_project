using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace db_web_project.Models
{
    public class PatientModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string CNIC { get; set; }

        public int HospitalId { get; set; }

        public int Age { get; set; }

        public string Gender { get; set; }

        public string Address { get; set; }

        public string WardName { get; set; }
    }
}
