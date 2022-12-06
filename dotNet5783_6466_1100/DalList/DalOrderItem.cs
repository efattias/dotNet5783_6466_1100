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
    public int Add(OrderItem? item)
    {
        if (item == null)
            throw new DO.InvalidItemException("null item");

        OrderItem? temp = ds.OrderItems.Find(x => x?.ID == item?.ID);

        if (temp != null)
            throw new AlreadyExistExeption("order item allready exists");

        OrderItem orderItem = (OrderItem)item;
        ds.OrderItems.Add(orderItem);

        return orderItem.ID;
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
    public void Update(OrderItem? item)
    {
        if (item == null)
            throw new DO.InvalidItemException("null item");

        OrderItem? temp = ds.OrderItems.Find(x => x?.ID == item?.ID);

        if (temp == null)
            throw new DoesntExistException(" does not exist");

        OrderItem orderItem = (OrderItem)item;
        Delete(orderItem.ID);
        Add(orderItem);
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
            throw new DoesntExistException("order not exist");
        if (temp?.ProductID == productId)
            return (OrderItem)temp;
        else throw new DoesntExistException(" product not exist");
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
}

