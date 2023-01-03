namespace DO;
/// <summary>
/// structure for product
/// </summary>
public struct Product
{
    /// <summary>
    ///  Unique Id of Product struct
    /// </summary>
    public int ID { get; set; }
    /// <summary>
    ///  Unique Name of Product struct
    /// </summary>
    public string? Name { get; set; }
    /// <summary>
    ///  Unique price of Product struct
    /// </summary>
    public double? Price { get; set; }
    /// <summary>
    ///  Unique Category of Product struct
    /// </summary>
    public Category? Category { get; set; }
    /// <summary>
    ///  Unique InStock of Product struct
    /// </summary>

    public int? InStock { get;set; }

    /// <summary>
    /// function ToString- print product struct
    /// </summary>
    /// <returns></returns>
    /// 

    /// <summary>
    /// path for image
    /// </summary>
    public string? path { get; set; }
    public override string ToString() => $@"
    
        Product ID={ID}: {Name}, 
        Category - {Category}
    	Price: {Price}
    	Amount in stock: {InStock}
";
}
