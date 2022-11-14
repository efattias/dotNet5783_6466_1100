

namespace DO;

/// <summary>
/// structure for order item
/// </summary>
public struct OrderItem
{
    /// <summary>
    /// Unique Id of OrderItem struct
    /// </summary>
    public int? ID { get; set; }
    /// <summary>
    ///  Unique ProductID of OrderItem struct
    /// </summary>
    public int? ProductID { get; set; }
    /// <summary>
    ///  Unique OrderID of OrderItem struct
    /// </summary>
    public int? OrderID { get; set; }
    /// <summary>
    ///  Unique Price of OrderItem struct
    /// </summary>
    public double? Price { get; set; }
    /// <summary>
    ///  Unique Amount of OrderItem struct
    /// </summary>
    public int? Amount { get; set; }

    /// <summary>
    /// function- print OrderItem struct
    /// </summary>
    /// <returns></returns>
    public override string ToString() => $@"
        ID={{ID}}
        Product ID={{ProductID}}
        Order ID={{OrderID}}
    	Price: {{Price}}
    	Amount: {{Amount}}
";


}
