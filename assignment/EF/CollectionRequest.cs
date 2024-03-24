using System;
using System.Collections.Generic;

namespace assignment.EF;

public partial class CollectionRequest
{
    public int Cid { get; set; }

    public int Rid { get; set; }

    public int Eid { get; set; }

    public string MaxPreservationTime { get; set; } = null!;

    public string Status { get; set; } = null!;

    public virtual Employee EidNavigation { get; set; } = null!;

    public virtual ICollection<Food> Foods { get; set; } = new List<Food>();
}
