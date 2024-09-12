using System;
using System.Collections.Generic;

namespace Bijoux_Jewelry.DataAccess.Models;

public partial class ProductType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
