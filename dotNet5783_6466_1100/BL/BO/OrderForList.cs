using DO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO;
/// <summary>
/// list of orders detail
/// </summary>
public class OrderForList
{
    /// <summary>
    /// id of the order
    /// </summary>
    public int ID { get; set; }
    /// <summary>
    /// customer name 
    /// </summary>
    public string? CustomerName { get; set; }
    /// <summary>
    /// Unique order status of OrderForList class
    /// </summary>
    public Status? OrderStatus { get; set; }
    /// <summary>
    /// The amount of items the customer ordered
    /// </summary>
    public int? AmountOfItems { get; set; }
    public double? TotalPrice { get; set; }

    public override string ToString() => $@"
        ID={ID}
        Customer name={CustomerName}
        Order status={OrderStatus}
        Amount of items: {AmountOfItems}
    	Total price: {TotalPrice}
";

}

