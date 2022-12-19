using DalApi;
using DO;
using System.Linq;

namespace Dal;
/// <summary>
/// class for implement the funcions of order item
/// </summary>
public class DalOrderItem:IOrderItem
{
    DataSource ds = DataSource.s_instance;
    #region CRUD function
    /// <summary>
    /// function- add order item to list
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public int Add(OrderItem item)
    {
        OrderItem? temp = ds.OrderItems.Find(x => x?.ID == item.ID);

        if (item.ID >= 1000 && temp==null)
        {
            ds.OrderItems.Add(item);
            return item.ID;
        }

        if (temp != null)
            throw new AlreadyExistExeption("order item allready exists");

        item.ID = DataSource.ConfigOrderItem.NextOrderItemNumber;
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
            throw new DoesntExistException("cant Delete that-order item does not exist");
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
            throw new DoesntExistException("order item does not exist");

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
            throw new DoesntExistException(" does not exist");

        Delete(item.ID);
        Add(item);
    }
    #endregion

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
        if (temp == null)
            throw new DoesntExistException("orderItem not exists");
        if (temp?.ProductID == productId)
            return (OrderItem)temp;
        else throw new DoesntExistException(" product not exist in order");
    }
    
    /// <summary>
    /// function- return order item list
    /// </summary>
    /// <returns></returns>
    public IEnumerable<OrderItem?> getAll(Func<OrderItem?, bool>? filter = null)
    {
        if (filter == null)
            return ds.OrderItems?.ToList<OrderItem?>()?? throw new DO.DoesntExistException("Orders list invalid");
        return ds.OrderItems.Where(x => filter(x)) ?? throw new DO.DoesntExistException("Orders list invalid"); ;
    }
    /// <summary>
    /// function-the function returns the items in order by given id
    /// </summary>
    /// <param name="orderId"></param>
    /// <returns></returns>
    public IEnumerable<OrderItem?> GetItemsList(int orderId)
    {
        Order? order = ds.Orders.Find(x => x.GetValueOrDefault().ID == orderId);
        if (order == null)
            throw new DoesntExistException("the order does not exist");
        List<OrderItem?> listToReturn = new List<OrderItem?>();
        foreach(OrderItem? item in ds.OrderItems)
        {
            if (item != null && item?.OrderID == order?.ID)
                listToReturn.Add((OrderItem?)item);  
        }
        return listToReturn;
    }
}

