using System;
using System.Collections.Generic;

namespace Bijoux_Jewelry.DataAccess.Models;

public partial class Product
{
    public int Id { get; set; }

    public string ImageUrl { get; set; } = null!;

    public int ProductTypeId { get; set; }

    public double? MountingSize { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<ProductDiamond> ProductDiamonds { get; set; } = new List<ProductDiamond>();

    public virtual ICollection<ProductMetal> ProductMetals { get; set; } = new List<ProductMetal>();

    public virtual ProductType ProductType { get; set; } = null!;

    public virtual ICollection<Quote> Quotes { get; set; } = new List<Quote>();
}
