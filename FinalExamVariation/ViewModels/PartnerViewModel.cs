using FinalExamVariation.Models;
using FinalExamVariation.Models.PartnerModels;
using FinalExamVariation.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExamVariation.ViewModels
{
    public class PartnerViewModel: ViewModelBase
    {
        public ObservableCollection<Partners> PartnerCollection { get; set; }
        private PartnerRepository PartnerRepository { get; set; }

        public PartnerViewModel()
        {
            PartnerRepository = new();
            PartnerCollection = new(PartnerRepository.Repository);
        }
    }
}
