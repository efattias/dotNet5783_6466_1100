using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO;
public class Cart
{
    /// <summary>
    /// Unique customer name of cart class
    /// </summary>
    public string? CustomerName { get; set; }
    /// <summary>
    /// Unique customer email of cart class
    /// </summary>
    public string? CustomerEmail { get; set; }
    /// <summary>
    /// Unique customer address of cart class
    /// </summary>
    public string? CustomerAddress { get; set; }
    /// <summary>
    /// Unique items of cart class
    /// </summary>
    public OrderItem? Items { get; set; }
    /// <summary>
    /// Unique total price of cart class
    /// </summary>
    public double? TotalPrice { get; set; }
    /// <summary>
    /// function- print Cart struct
    /// </summary>
    /// <returns></returns>
    public override string ToString() => $@"
        Customer name: {CustomerName}
        Customer email: {CustomerEmail}
        Customer address: {CustomerAddress}
        Items: {Items}
        Total price:{TotalPrice}
";
}



