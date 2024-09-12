using System;
using System.Collections.Generic;

namespace Bijoux_Jewelry.DataAccess.Models;

public partial class DiamondClarity
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Diamond> Diamonds { get; set; } = new List<Diamond>();
}
