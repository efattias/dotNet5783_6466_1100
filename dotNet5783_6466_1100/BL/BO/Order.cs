using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO;
public class Order
{
    public int ID { get; set; }
    public string? CustomerName { get; set; }
    public string? CustomerEmail { get; set; }
    public string? CustomerAddress { get; set; }
    public DateTime? OrderDate { get; set; }
    public Status? OrderStatus { get; set; }
    public DateTime? PaymantDate { get; set; }
    public DateTime? ShipDate { get; set; }
    public DateTime? DeliveryDate { get; set; }
    public OrderItem? Items { get; set; }
    public double? TotalPrice { get; set; }
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
