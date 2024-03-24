using System;
using System.Collections.Generic;

namespace assignment.EF;

public partial class Restaurant
{
    public int Rid { get; set; }

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;
}