using Lab1_RPM2.Data;
using Lab1_RPM2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_RPM2.ViewModel
{
    public class PartnerHistoryViewModel
    {
        public string PartnerTitle { get; set; }
        public ObservableCollection<ProductPartner> ProductPartnerItem { get; set; } = new();

        public PartnerHistoryViewModel(Partner partner)
        {
            PartnerTitle = partner.TitlePa;
            LoadSaleHistory(partner.Inn.ToString());
        }
   

        private void LoadSaleHistory(string partnerInn)
        {
            using var context = new AppDBContext();
            var sales = context.ProductPartners
                .Include(s => s.ArticleProduct)
                .Where(s => s.InnPatners.ToString() == partnerInn)
                .Select(s => new ProductPartner()
                {
                    //ArticleProductNavigation           
                    QuantityProducts = s.QuantityProducts,
                    DateSales = s.DateSales
                })
                .ToList();

            //foreach (var sale in sales) ;
                //SaleHistory.Add(sale);
        }
    }
}
