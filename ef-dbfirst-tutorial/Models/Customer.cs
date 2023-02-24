using System;
using System.Collections.Generic;

namespace ef_dbfirst_tutorial.Models;

public partial class Customer
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string City { get; set; } = null!;

    public string State { get; set; } = null!;

    public decimal Sales { get; set; }

    public bool? Active { get; set; }

    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
