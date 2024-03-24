using System;
using System.Collections.Generic;

namespace assignment.EF;

public partial class Employee
{
    public int Eid { get; set; }

    public string Name { get; set; } = null!;

    public int Number { get; set; }

    public virtual ICollection<CollectionRequest> CollectionRequests { get; set; } = new List<CollectionRequest>();
}
