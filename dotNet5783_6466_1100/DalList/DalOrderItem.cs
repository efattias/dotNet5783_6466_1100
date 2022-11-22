using DalApi;
using DO;

namespace Dal;

public class DalOrderItem:IOrderItem
{
    DataSource ds = DataSource.s_instance;
    public int Add(OrderItem item)
    {
        OrderItem? temp = ds.OrderItems.Find(x => x?.ID == item.ID);
        if (temp != null)
            throw new Exception("order allready exists");
        ds.OrderItems.Add(item);
        return item.ID;
    }
    public void Delete(int id)
    {
        if (ds.OrderItems.RemoveAll(OrderItem => OrderItem?.ID == id) == 0)
            throw new Exception("cant Delete that does not exist");
    }
    public OrderItem GetByID(int id)
    {
        OrderItem? temp = ds.OrderItems.Find(x => x?.ID == id);
        if (temp == null)
            throw new Exception("order is not exists");
        return (OrderItem)temp;
    }

    public void Update(OrderItem item)
    {
        OrderItem? temp = ds.OrderItems.Find(x => x?.ID == item.ID);
        if (temp == null)
            throw new Exception("not exist");
        Delete(item.ID);
        Add(item);
    }
    public OrderItem GetProductByOrderAndID(int orderId, int productId)
    {
        OrderItem? temp = ds.OrderItems.Find(x => x?.OrderID == orderId);

        //OrderItem? temp1 = ds.OrderItems.Find(x => x?.ProductID == productId);
        if (temp == null)
            throw new Exception("order not exist");
        if (temp?.ProductID == productId)
            return (OrderItem)temp;
        else throw new Exception(" product not exist");
    }
}

