﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace db_web_project.Models
{
    public class WardModel
    {
        [Key]
        public Guid WardId { get; set; }

        public string WardName { get; set; }

        public string WardCategory { get; set; }

        public int WardCapacity { get; set; }
    }
}
