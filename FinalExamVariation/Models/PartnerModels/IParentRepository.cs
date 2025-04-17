using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExamVariation.Models.PartnerModels
{
    public interface IParentRepository
    {
        List<Partners> GetAll();
    }
}
