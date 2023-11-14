﻿using System;
using System.Collections.Generic;

namespace APIGri.DBModel;

public partial class Order
{
    public int OrderId { get; set; }

    public DateOnly? OrderDate { get; set; }

    public int? UserId { get; set; }

    public virtual ICollection<OrderService> OrderServices { get; set; } = new List<OrderService>();

    public virtual User? User { get; set; }
}
