﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExamVariation.Models
{
    public class PartnerTypes
    {
        [Key]
        public int ID { get; set; }
        public string Title { get; set; }
    }
}
