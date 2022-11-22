using DalApi;
using DO;
//using System.Collections.Generic;

namespace Dal;

public class DalOrder : IOrder// לממש את המתודות של iorder
{
    public readonly Random rnd = new Random();
    DataSource ds = DataSource.s_instance;
    public int Add(Order item)
    {
        Order? temp = ds.Orders.Find(x => x?.ID == item.ID);
        if (temp != null)
            throw new Exception("order allready exists");
        item.OrderDate = DateTime.Now - new TimeSpan(rnd.NextInt64(10L * 1000L * 1000L * 3600L * 24L * 10L));
        item.ShipDate = DateTime.Now - new TimeSpan(rnd.NextInt64(10L * 1000L * 1000L * 3600L * 24L * 10L));
        item.DeliveryDate = DateTime.Now - new TimeSpan(rnd.NextInt64(10L * 1000L * 1000L * 3600L * 24L * 10L));
        ds.Orders.Add(item);
        return item.ID;
    }
    public void Delete(int id)
    {
        if (ds.Orders.RemoveAll(Order => Order?.ID == id) == 0)
            throw new Exception("cant Delete that does not exist");
    }
    public Order GetByID(int id) //=> ds.Orders.FirstOrDefault() ?? throw new Exception("missing order id");
    {
        Order? temp = ds.Orders.Find(x => x?.ID == id);
        if (temp == null)
            throw new Exception("order is not exists");
        return (Order)temp;
    }
    public void Update(Order item)
    {
        Order? temp = ds.Orders.Find(x => x?.ID == item.ID);
        if (temp == null)
            throw new Exception("not exist");
        Delete(item.ID);
        Add(item);
    }
    //public IEnumerable<Order> getAll()
    //{
    //    return (from Order in ds.Orders select Order).ToList<Order>();
    //}
}