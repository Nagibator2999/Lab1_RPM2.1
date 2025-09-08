using System;
using System.Collections.Generic;

namespace Lab1_RPM2.Models;

public partial class ProductPartner
{
    public int Number { get; set; }

    public int? ArticleProduct { get; set; }

    public long? InnPatners { get; set; }

    public int? QuantityProducts { get; set; }

    public DateTime? DateSales { get; set; }

    public virtual Product? ArticleProductNavigation { get; set; }

    public virtual Partner? InnPatnersNavigation { get; set; }
}
