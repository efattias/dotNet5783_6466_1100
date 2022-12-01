using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO;
public class Order
{
    /// <summary>
    /// Unique ID of order class
    /// </summary>
    public int ID { get; set; }
    /// <summary>
    /// Unique customer name of order class
    /// </summary>
    public string? CustomerName { get; set; }
    /// <summary>
    /// Unique customer email of order class
    /// </summary>
    public string? CustomerEmail { get; set; }
    /// <summary>
    /// Unique customer address of order class
    /// </summary>
    public string? CustomerAddress { get; set; }
    /// <summary>
    /// Unique order date of order class
    /// </summary>
    public DateTime? OrderDate { get; set; }
    /// <summary>
    /// Unique order status of order class
    /// </summary>
    public Status? OrderStatus { get; set; }
    /// <summary>
    /// Unique paymant date of order class
    /// </summary>
    public DateTime? PaymantDate { get; set; }
    /// <summary>
    /// Unique ship date of order class
    /// </summary>
    public DateTime? ShipDate { get; set; }
    /// <summary>
    /// Unique delivery date of order class
    /// </summary>
    public DateTime? DeliveryDate { get; set; }
    /// <summary>
    /// Unique items of order class
    /// </summary>
    public OrderItem? Items { get; set; }
    /// <summary>
    /// Unique total price of order class
    /// </summary>
    public double? TotalPrice { get; set; }
    /// <summary>
    /// function- print order class
    /// </summary>
    /// <returns></returns>
    public override string ToString() => $@"
        ID={ID}
        Customer name: {CustomerName}
        Customer email: {CustomerEmail}
        Customer address: {CustomerAddress}
        Date of order: {OrderDate}
        Order status: {OrderStatus}
        Date of paymant: {PaymantDate}
        Date of ship:{ShipDate}
        Date of delivery: {DeliveryDate}
        Items: {Items}
        Total price {TotalPrice}
";
}
