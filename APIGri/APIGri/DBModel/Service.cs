using System;
using System.Collections.Generic;

namespace APIGri.DBModel;

public partial class Service
{
    public int ServiceId { get; set; }

    public string? ServiceName { get; set; }

    public decimal? Price { get; set; }

    public virtual ICollection<OrderService> OrderServices { get; set; } = new List<OrderService>();
}
