using System;
using System.Collections.Generic;

namespace assignment.EF;

public partial class Food
{
    public int Fid { get; set; }

    public int Cid { get; set; }

    public string Name { get; set; } = null!;

    public int Quantity { get; set; }

    public DateOnly Expire { get; set; }

    public virtual CollectionRequest CidNavigation { get; set; } = null!;
}
