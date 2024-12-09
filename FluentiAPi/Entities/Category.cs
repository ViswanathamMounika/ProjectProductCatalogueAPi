using System;
using System.Collections.Generic;

namespace FluentiAPi.Entities;

public partial class Category
{
    public int CategoryId { get; set; }

    public string? CategoryName { get; set; }

    public virtual ICollection<Product> ProductsManagements { get; set; } = new List<Product>();
}
