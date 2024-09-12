using System;
using System.Collections.Generic;

namespace Bijoux_Jewelry.DataAccess.Models;

public partial class ProductionStatus
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<ProductionProcess> ProductionProcesses { get; set; } = new List<ProductionProcess>();
}
