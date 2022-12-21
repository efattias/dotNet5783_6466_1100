using DalApi;
using DO;
namespace Dal;

/// <summary>
/// class for implement the funcions of order
/// </summary>
public class DalOrder : IOrder
{
    public readonly Random rnd = new Random();// random variable 
    DataSource ds = DataSource.s_instance;

    #region CRUD function
    /// <summary>
    /// function- add order to order list
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public int Add(Order item)
    {
      
        Order? temp = ds.Orders.Find(x => x?.ID == item.ID);

        if (item.ID >= 1000 && temp == null)
        {
            ds.Orders.Add(item);
            return item.ID;
        }

        if (temp != null)
            throw new AlreadyExistExeption("order item allready exists");

        item.ID = DataSource.ConfigOrder.NextOrderNumber;
        ds.Orders.Add(item);
        return item.ID;
    }
    
    /// <summary>
    /// function- delete order from order list
    /// </summary>
    /// <param name="id"></param>
    /// <exception cref="Exception"></exception>
    public void Delete(int id)
    {
        if (ds.Orders.RemoveAll(Order => Order?.ID == id) == 0)
            throw new DoesntExistException("cant Delete that- order does not exist");
    }
    
    /// <summary>
    ///function- get order from list by given id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public Order GetByID(int id)
    { 
        Order? temp = ds.Orders.Find(x => x?.ID == id);
        if (temp == null)
            throw new DoesntExistException("order does not exist");
        return (Order)temp;
    }
    
    /// <summary>
    /// function- update order in the list
    /// </summary>
    /// <param name="item"></param>
    /// <exception cref="Exception"></exception>
    public void Update(Order item)
    {
        Order? temp = ds.Orders.Find(x => x?.ID == item.ID);

        if (temp == null)
            throw new DoesntExistException("order does not exist");

        Delete(item.ID);
        Add(item);
    }
    #endregion

    /// <summary>
    /// function- return list of orders
    /// </summary>
    /// <returns></returns>
    public IEnumerable<Order?> getAll(Func<Order?, bool>? filter = null)
    {
        if(filter == null)  
            return  ds.Orders?.ToList<Order?>() ?? throw new DO.DoesntExistException("Orders list invalid");
        return ds.Orders.Where(x => filter(x)) ?? throw new DO.DoesntExistException("Orders list invalid"); ;
    }
    /// <summary>
    /// function- returns an order by filter
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>

    public Order? getByFilter(Func<Order?, bool>? filter)
    { 
        var order= ds.Orders.Where(x => filter(x)) ?? throw new DoesntExistException("order by filter doesnt exists");
        return order.First();
    }
}