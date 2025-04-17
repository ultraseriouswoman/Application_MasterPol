using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExamVariation.Models
{
    public class Partners
    {
        [Key]
        public int ID { get; set; }
        public int PartnerTypeID { get; set; }
        [ForeignKey("PartnerTypeID")]
        public PartnerTypes PartnerType { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public string Email { get; set; }
        public string Number { get; set; }
        public int AddressID { get; set; }
        [ForeignKey("AddressID")]
        public Addresses Address { get; set; }
        public string INN { get; set; }
        public int Rating { get; set; }
    }
}
