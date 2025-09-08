using System;
using System.Collections.Generic;

namespace Lab1_RPM2.Models;

public partial class Product
{
    public int Article { get; set; }

    public int? TypeProduct { get; set; }

    public string? TitlePr { get; set; }

    public double? MinPrice { get; set; }

    public virtual ICollection<ProductPartner> ProductPartners { get; set; } = new List<ProductPartner>();

    public virtual TypeProduct? TypeProductNavigation { get; set; }
}
