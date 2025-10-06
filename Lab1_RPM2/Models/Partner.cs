using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab1_RPM2.Models;

public partial class Partner
{
    public long Inn { get; set; }

    public string? TypePartner { get; set; }

    public string? TitlePa { get; set; }

    public string? Director { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public string? UrAdress { get; set; }

    public int? Rating { get; set; }

    public virtual ICollection<ProductPartner> ProductPartners { get; set; } = new List<ProductPartner>();
    [NotMapped]
    public int Discount { get
        {
            int TotalSales = ProductPartners.Sum(p => p.QuantityProducts) ?? 0;
            if (TotalSales < 10_000) return 0;
            if (TotalSales < 50_000) return 5;
            if (TotalSales < 300_000) return 10;
            return 15;
        }
    }
    //public ObservableCollection<string> PartnerTypes { get; } = new ObservableCollection<string>
    //{
    //        "ООО",
    //        "ОАО",
    //        "ЗАО",
    //        "ПАО"
    //};

}
