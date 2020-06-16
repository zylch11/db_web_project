﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace db_web_project.Models
{
    public class HospitalModel
    {
        [Key]
        public int HospitalId { get; set; }

        public string HospitalName { get; set; }

        public string HospitalAddress { get; set; }
    }
}
