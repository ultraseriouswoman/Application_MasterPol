using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExamVariation.Models
{
    public class Sales
    {
        public int PartnerID { get; set; }
        [ForeignKey("PartnerID")]
        public Partners Partner { get; set; }
        public int Count { get; set; }
    }
}
