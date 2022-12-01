namespace DO;
/// <summary>
/// structure for order
/// </summary>
public struct Order
{/// <summary>
/// Unique ID of order struct
/// </summary>
    public int ID { get; set; }
    /// <summary>
    /// Unique CustomerName of order struct
    /// </summary>
    public string? CustomerName { get; set; }
    /// <summary>
    /// Unique  of CustomerEmail order struct
    /// </summary>
    public string? CustomerEmail { get; set; }
    /// <summary>
    /// Unique CustomerAddress of order struct
    /// </summary>
    public string? CustomerAddress { get; set; }
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
        ID={ID}
        Customer name: {CustomerName}
        Customer email: {CustomerEmail}
        Customer address: {CustomerAddress}
        Date of order: {OrderDate}
        Date of ship:{ShipDate}
        Date of delivery: {DeliveryDate}
";
}
