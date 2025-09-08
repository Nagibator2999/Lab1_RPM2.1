using System;
using System.Collections.Generic;

namespace Lab1_RPM2.Models;

public partial class TypeProduct
{
    public int Number { get; set; }

    public string? TypeP { get; set; }

    public double? TypeKoef { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
