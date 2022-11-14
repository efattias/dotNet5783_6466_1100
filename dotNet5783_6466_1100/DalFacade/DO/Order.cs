//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace DO;
/// <summary>
/// structure for order
/// </summary>
public struct Order
{/// <summary>
/// Unique ID of order struct
/// </summary>
    public int? ID { get; set; }
    /// <summary>
    /// Unique CustomerName of order struct
    /// </summary>
    public string? CustomerName { get; set; }
    /// <summary>
    /// Unique  of CustomerEmail order struct
    /// </summary>
    public string? CustomerEmail { get; set; }
    /// <summary>
    /// Unique CustomerAdress of order struct
    /// </summary>
    public string? CustomerAdress { get; set; }
    /// <summary>
    /// Unique OrderDate of order struct
    /// </summary>
    public DateTime? OrderDate { get; set; }
    /// <summary>
    /// Unique ShipDate of order struct
    /// </summary>
    public DateTime? ShipDate { get; set; }
    /// <summary>
    /// Unique DeliveryDate of order struct
    /// </summary>
    public DateTime? DeliveryDate { get; set; }
    /// <summary>
    /// function- print Order struct
    /// </summary>
    /// <returns></returns>
    public override string ToString() => $@"
        ID={{ID}}
        Customer name: {{CustomerName}}
        Customer email: {{CustomerEmail}}
        Customer adress: {{CustomerAdress}}
        date of order: {{OrderDate}}
        date of ship:{{ShipDate}}
        date of delivery: {{DeliveryDate}}
";


}
