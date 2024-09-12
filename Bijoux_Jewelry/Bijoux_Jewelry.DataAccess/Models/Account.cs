using System;
using System.Collections.Generic;

namespace Bijoux_Jewelry.DataAccess.Models;

public partial class Account
{
    public int Id { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? Phone { get; set; }

    public DateOnly? Dob { get; set; }

    public string Email { get; set; } = null!;

    public string Fullname { get; set; } = null!;

    public int Role { get; set; }

    public DateTime Created { get; set; }

    public byte Status { get; set; }

    public virtual ICollection<Order> OrderAccounts { get; set; } = new List<Order>();

    public virtual ICollection<Order> OrderDesignStaffs { get; set; } = new List<Order>();

    public virtual ICollection<Order> OrderProductionStaffs { get; set; } = new List<Order>();

    public virtual ICollection<Quote> QuoteAccounts { get; set; } = new List<Quote>();

    public virtual ICollection<Quote> QuoteDesignStaffs { get; set; } = new List<Quote>();

    public virtual ICollection<Quote> QuoteProductionStaffs { get; set; } = new List<Quote>();
}
