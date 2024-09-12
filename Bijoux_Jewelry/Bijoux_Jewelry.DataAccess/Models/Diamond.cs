using System;
using System.Collections.Generic;

namespace Bijoux_Jewelry.DataAccess.Models;

public partial class Diamond
{
    public int Id { get; set; }

    public double Size { get; set; }

    public string ImageUrl { get; set; } = null!;

    public int DiamondColorId { get; set; }

    public int DiamondOriginId { get; set; }

    public int DiamondClarityId { get; set; }

    public double Price { get; set; }

    public byte Status { get; set; }

    public DateTime Created { get; set; }

    public virtual DiamondClarity? DiamondClarity { get; set; } = null!;

    public virtual DiamondColor? DiamondColor { get; set; } = null!;

    public virtual DiamondOrigin? DiamondOrigin { get; set; } = null!;

    public virtual ICollection<ProductDiamond> ProductDiamonds { get; set; } = new List<ProductDiamond>();
}
