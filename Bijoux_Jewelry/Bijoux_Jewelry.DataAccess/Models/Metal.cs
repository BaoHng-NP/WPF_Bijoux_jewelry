using System;
using System.Collections.Generic;

namespace Bijoux_Jewelry.DataAccess.Models;

public partial class Metal
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public double BuyPricePerGram { get; set; }

    public double SalePricePerGram { get; set; }

    public string ImageUrl { get; set; } = null!;

    public double SpecificWeight { get; set; }

    public byte Deactivated { get; set; }

    public DateTime Created { get; set; }

    public virtual ICollection<ProductMetal> ProductMetals { get; set; } = new List<ProductMetal>();
}
