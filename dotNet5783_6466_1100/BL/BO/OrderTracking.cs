using DO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO;
public class OrderTracking
{
    public int ID { get; set; }
    public Status? OrderStatus { get; set; }

    public override string ToString() => $@"
        ID={ID}
        Order status={OrderStatus}
";
}

