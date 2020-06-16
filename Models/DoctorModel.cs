using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace db_web_project.Models
{
    public class Doctor
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Qualification { get; set; }

        public int Age { get; set; }

        public int CNIC { get; set; }

        public int HospitalId { get; set; }

        public string Role { get; set; }
    }
}
