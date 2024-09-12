using System;
using System.Collections.Generic;

namespace Bijoux_Jewelry.DataAccess.Models;

public partial class Quote
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int AccountId { get; set; }

    public int QuoteStatusId { get; set; }

    public double ProductPrice { get; set; }

    public double ProductionPrice { get; set; }

    public double ProfitRate { get; set; }

    public double TotalPrice { get; set; }

    public string? Note { get; set; }

    public int? DesignStaffId { get; set; }

    public int? ProductionStaffId { get; set; }

    public DateTime Created { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual Account? DesignStaff { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual Account? ProductionStaff { get; set; }

    public virtual QuoteStatus QuoteStatus { get; set; } = null!;
}
