using System;
using System.Collections.Generic;

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

    
}
