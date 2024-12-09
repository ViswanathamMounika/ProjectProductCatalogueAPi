using System;
using System.Collections.Generic;

namespace FluentiAPi.Entities;

public partial class Product
{
    public Guid ProductId { get; set; }

    public int? CategoryId { get; set; }

    public string? ProdName { get; set; }

    public string? ProdBrand { get; set; }

    public string? ProdDescription { get; set; }

    public double? ProdPrice { get; set; }

    public virtual Category? Category { get; set; }
}
