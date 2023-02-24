using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ef_dbfirst_tutorial.Models;

public partial class Order
{
    public int Id { get; set; }

    public int? CustomerId { get; set; }

    public DateTime Date { get; set; }

    public string? Description { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual ICollection<OrderLine> OrderLines { get; } = new List<OrderLine>();

    public override string ToString()
    {
        var message = $"ID: {Id,2} | Name: {Customer.Name,-10} | Customer ID: {CustomerId,2} | Date: {Date,-8} | Description: {Description,-22}";
        foreach (var ordline in OrderLines)
        {
            message += $"\n\nID: {ordline.Id,2} | Product: {ordline.Product,-15} | Description: {ordline.Description,-20} | Price: {ordline.Price,10:C} | Qantity: {ordline.Quantity}";
        }
        return message ;
    }
}
