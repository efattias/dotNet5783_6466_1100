    using BlApi;
using DO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO;
/// <summary>
/// track after order status
/// </summary>
public class OrderTracking
{
    /// <summary>
    /// order id
    /// </summary>
    public int ID { get; set; }
    /// <summary>
    /// order status
    /// </summary>
    public Status? OrderStatus { get; set; }

    public List<Tuple<DateTime?, string>>? trackList { get; set; }

    /// <summary>
    /// function- print OrderTracking class
    /// </summary>
    /// <returns></returns>
    /// 
    public override string ToString() => this.ToStringProperty();

    //    public override string ToString() => $@"
    //        ID={ID}
    //        Order status={OrderStatus}
    //";
}

