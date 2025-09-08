using System;
using System.Collections.Generic;

namespace Lab1_RPM2.Models;

public partial class Material
{
    public int Number { get; set; }

    public string? TypeMaterial { get; set; }

    public double? PercentDefect { get; set; }
}
