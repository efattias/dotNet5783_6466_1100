using DalApi;
using DO;

namespace Dal;

public class DalProduct:IProduct
{
    DataSource ds = DataSource.s_instance;
    public int Add(Product item)
    {
        Product? temp = ds.products.Find(x => x?.ID == item.ID);
        if (temp != null)
            throw new Exception("product allready exists");
        ds.products.Add(item);
        return item.ID;
    }
    public void Delete(int id)
    {
        if (ds.products.RemoveAll(Product => Product?.ID == id) == 0)
            throw new Exception("cant Delete that does not exist");
    }
    public Product GetByID(int id) 
    { 
        Product? temp = ds.products.Find(x => x?.ID == id);
        if (temp == null)
            throw new Exception("product is not exists");
        return (Product)temp;
    }
    public void Update(Product item)
    {
        Product? temp = ds.products.Find(x => x?.ID == item.ID);
        if (temp == null)
            throw new Exception("not exist");
        Delete(item.ID);
        Add(item);
    }
    public IEnumerable<Product> getAll()
    {
        return (from Product product in ds.products select product).ToList<Product>();
    }
}