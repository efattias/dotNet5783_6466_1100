

using DalApi;
using DO;

namespace Dal;

public class DalProduct:IProduct
{
    DataSource ds = DataSource.s_instance;
    public int Add(Product item)
    {
        if (ds.products.FirstOrDefault() != null)
            throw new NotImplementedException();
        item.ID = DataSource.Config.NextOrderNumber;
        ds.products.Add(item);
        return item.ID;
    }
    public void Delete(int id)
    {
        if (ds.products.RemoveAll(Product => Product?.ID == id) == 0)
            throw new Exception("cant Delete that does not exist");
    }
    public Product GetByID(int id) => ds.products.FirstOrDefault() ?? throw new Exception("missing product id");

    public void Update(Product item)
    {
        Product? temp = ds.products.Find(x => x?.ID == item.ID);
        if (temp == null)
            throw new Exception("not exist");
        Delete(item.ID);
        Add(item);
    }
}
