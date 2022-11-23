using DalApi;
using DO;

namespace Dal;
/// <summary>
/// class for implement the funcions of order item
/// </summary>
public class DalOrderItem:IOrderItem
{
    DataSource ds = DataSource.s_instance;
    /// <summary>
    /// function- add order item to list
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public int Add(OrderItem item)
    {
        OrderItem? temp = ds.OrderItems.Find(x => x?.ID == item.ID);
        if (temp != null)
            throw new Exception("order allready exists");
        ds.OrderItems.Add(item);
        return item.ID;
    }
    /// <summary>
    /// function- delete item order from list
    /// </summary>
    /// <param name="id"></param>
    /// <exception cref="Exception"></exception>
    public void Delete(int id)
    {
        if (ds.OrderItems.RemoveAll(OrderItem => OrderItem?.ID == id) == 0)
            throw new Exception("cant Delete that does not exist");
    }
    /// <summary>
    /// function- get order item from list by given id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public OrderItem GetByID(int id)
    {
        OrderItem? temp = ds.OrderItems.Find(x => x?.ID == id);
        if (temp == null)
            throw new Exception("order is not exists");
        return (OrderItem)temp;
    }
    /// <summary>
    /// function-update order item in list
    /// </summary>
    /// <param name="item"></param>
    /// <exception cref="Exception"></exception>
    public void Update(OrderItem item)
    {
        OrderItem? temp = ds.OrderItems.Find(x => x?.ID == item.ID);
        if (temp == null)
            throw new Exception("not exist");
        Delete(item.ID);
        Add(item);
    }
    /// <summary>
    /// get product from  order item by its order id and profuct id
    /// </summary>
    /// <param name="orderId"></param>
    /// <param name="productId"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
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
    /// <summary>
    /// function- return order item list
    /// </summary>
    /// <returns></returns>
    public IEnumerable<OrderItem> getAll()
    {
        return (from OrderItem order in ds.OrderItems select order).ToList<OrderItem>();
    }
}

