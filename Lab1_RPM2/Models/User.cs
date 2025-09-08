using System;
using System.Collections.Generic;

namespace Lab1_RPM2.Models;

public partial class User
{
    public int UserId { get; set; }

    public string? Fio { get; set; }

    public long? Phone { get; set; }

    public string? Login1 { get; set; }

    public string? Password1 { get; set; }

    public string? Type1 { get; set; }
}
