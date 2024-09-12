using System;
using System.Collections.Generic;

namespace Bijoux_Jewelry.DataAccess.Models;

public partial class ProductMetal
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int MetalId { get; set; }

    public double Weight { get; set; }

    public byte Status { get; set; } = 1;

    public double Price { get; set; }

    public virtual Metal Metal { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
