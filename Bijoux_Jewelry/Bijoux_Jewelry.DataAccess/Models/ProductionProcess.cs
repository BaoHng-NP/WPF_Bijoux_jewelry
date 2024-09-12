using System;
using System.Collections.Generic;

namespace Bijoux_Jewelry.DataAccess.Models;

public partial class ProductionProcess
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public int ProductionStatusId { get; set; }

    public string? ImageUrl { get; set; }

    public DateTime Created { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual ProductionStatus ProductionStatus { get; set; } = null!;
}
