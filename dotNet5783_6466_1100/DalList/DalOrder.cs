
using DalApi;
using DO;

namespace Dal;

public class DalOrder : IOrder// לממש את המתודות של iorder
{
    DataSource ds = DataSource.s_instance;
    public int Add(Order item)
    {
        if (ds.Orders.FirstOrDefault() != null)
            throw new NotImplementedException();
        item.ID = DataSource.Config.NextOrderNumber;
        ds.Orders.Add(item);
        return item.ID;
    }
    public void Delete(int id)
    {
        if (ds.Orders.RemoveAll(Order => Order?.ID == id) == 0)
            throw new Exception("cant Delete that does not exist");
    }
    public Order GetByID(int id) => ds.Orders.FirstOrDefault() ?? throw new Exception("missing order id");

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

    //}


}
