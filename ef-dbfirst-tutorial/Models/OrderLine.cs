using System;
using System.Collections.Generic;

namespace ef_dbfirst_tutorial.Models;

public partial class OrderLine
{
    public int Id { get; set; }

    public int OrdersId { get; set; }

    public string Product { get; set; } = null!;

    public string? Description { get; set; }

    public int Quantity { get; set; }

    public decimal Price { get; set; }

    public virtual Order Orders { get; set; } = null!;

    public override string ToString()
    {
        return $"ID: {Id,2} | OrderID: {OrdersId,2} | Product: {Product,-8} | Description: {Description,-22} | Quantity: {Quantity,-3} | Price: {Price,10:C}";
    }
}
