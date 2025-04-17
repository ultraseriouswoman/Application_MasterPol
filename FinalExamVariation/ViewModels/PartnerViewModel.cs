using FinalExamVariation.Models;
using FinalExamVariation.Models.PartnerModels;
using FinalExamVariation.Models.SaleModels;
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
        private ObservableCollection<Sales> SaleCollection { get; set; }
        private PartnerRepository PartnerRepository { get; set; }
        private SaleRepository SaleRepository { get; set; }
        public PartnerViewModel()
        {
            PartnerRepository = new();
            PartnerCollection = new(PartnerRepository.Repository);

            SaleRepository = new();
            SaleCollection = new(SaleRepository.Repository);
            
            foreach (Partners partner in PartnerCollection)
            {
                CalculateDiscount(SaleCollection, partner);
            }
        }

        public static void CalculateDiscount(ObservableCollection<Sales> sales, Partners partner)
        {
            Sales s = sales.FirstOrDefault(x => x.PartnerID == partner.ID);
            s.PartnerID = partner.ID;
            if (s.PartnerID == null)
                throw new Exception("Партнера потеряли...");

            if (s.Count < 15000)
            {
                partner.Discount = 0.00F;
                partner.DiscountProc = Convert.ToString(partner.Discount * 100) + "%";
            }
            else if (s.Count > 15000 && s.Count < 50000)
            {
                partner.Discount = 0.05F;
                partner.DiscountProc = Convert.ToString(partner.Discount * 100) + "%";
            }
            else if (s.Count > 50000 && s.Count < 300000)
            {
                partner.Discount = 0.10F;
                partner.DiscountProc = Convert.ToString(partner.Discount * 100) + "%";
            }
            else if (s.Count > 300000)
            {
                partner.Discount = 0.15F;
                partner.DiscountProc = Convert.ToString(Math.Round(partner.Discount * 100)) + "%"; //Не спрашивайте
            }
            else
            {
                throw new Exception("Я в шоках... Пусть идет и покупает все у нас! Але!");
            } 
        }
    }
}
