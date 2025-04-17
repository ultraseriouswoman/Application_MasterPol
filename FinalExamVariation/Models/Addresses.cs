using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExamVariation.Models
{
    public class Addresses
    {
        [Key]
        public int ID { get; set; }
        public int PortalCode { get; set; }
        public string Region { get; set; }
        public string Town { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string FullAddress { get; set; }
    }
}
