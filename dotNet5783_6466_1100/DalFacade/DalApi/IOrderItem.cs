using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalApi;

public interface IOrderItem:ICrud<OrderItem>
{
    public List<OrderItem> getItemList(int orderId);
    public Product GetProduct(int orderId, int productId);
}
