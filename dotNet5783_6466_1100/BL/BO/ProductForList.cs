using BlApi;
using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO;

/// <summary>
/// class product for list
/// </summary>
public class ProductForList
{
    /// <summary>
    /// product id 
    /// </summary>
    public int ID { get; set; }
    /// <summary>
    /// product name 
    /// </summary>
    public string? Name { get; set; }
    /// <summary>
    /// product price
    /// </summary>
    public double? Price { get; set; }
    /// <summary>
    /// product category
    /// </summary>
    public Category? Category { get; set; }

    /// <summary>
    /// path for image
    /// </summary>
    public string? Path { get; set; }

    /// <summary>
    /// function- print ProductForList class
    /// </summary>
    /// <returns></returns>
    /// 

    public override string ToString() => this.ToStringProperty();

    //    public override string ToString() => $@"
    //        ID={ID}
    //        Name: {Name}
    //    	Price: {Price}
    //    	Category:{Category}
    //";
}
