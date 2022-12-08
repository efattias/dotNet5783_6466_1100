
namespace BO;
public class Cart
{
    /// <summary>
    /// Unique CustomerName of Cart class
    /// </summary>
    public string? CustomerName { get; set; }
    /// <summary>
    /// Unique CustomerEmail of Cart class
    /// </summary>
    public string? CustomerEmail { get; set; }
    /// <summary>
    /// Unique CustomerAddress of Cart class
    /// </summary>
    public string? CustomerAddress { get; set; }
    /// <summary>
    /// Unique list of Items of Cart class
    /// </summary>
    public List<OrderItem?>? Items { get; set; }
    /// <summary>
    /// Unique total price of Cart class
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



