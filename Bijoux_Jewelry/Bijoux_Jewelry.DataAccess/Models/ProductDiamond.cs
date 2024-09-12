using System;
using System.Collections.Generic;

namespace Bijoux_Jewelry.DataAccess.Models;

public partial class ProductDiamond
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int DiamondId { get; set; }

    public int Count { get; set; }

    public double Price { get; set; }

    public byte Status { get; set; }

    public virtual Diamond Diamond { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
