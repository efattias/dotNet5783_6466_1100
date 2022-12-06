using DalApi;
using DO;
using System.ComponentModel.Design;

namespace Dal;
/// <summary>
/// class for implement the funcions of order product
/// </summary>
public class DalProduct:IProduct
{
    DataSource ds = DataSource.s_instance;

    #region CRUD function

    /// <summary>
    /// function- add product to list
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public int Add(Product item)
    {
        Product? temp = ds.products.Find(x => x?.ID == item.ID);

        if (temp != null)
            throw new AlreadyExistExeption("product allready exists");

        Product product = (Product)item;

        ds.products.Add(item);
        return item.ID;
    }
    
    /// <summary>
    /// function- delete product from list
    /// </summary>
    /// <param name="id"></param>
    /// <exception cref="Exception"></exception>
    public void Delete(int id)
    {
        if (ds.products.RemoveAll(Product => Product?.ID == id) == 0)
            throw new DoesntExistException("cant Delete that - does not exist");
    }
    
    /// <summary>
    /// function- get product from list by given id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public Product GetByID(int id) 
    { 
        Product? temp = ds.products.Find(x => x?.ID == id);
        if (temp == null)
            throw new DoesntExistException("product does not exist");
        return (Product)temp;
    }
    
    /// <summary>
    /// function- update product in list
    /// </summary>
    /// <param name="item"></param>
    /// <exception cref="Exception"></exception>
    public void Update(Product item)
    {
        Product? temp = ds.products.Find(x => x?.ID == item.ID);

        if (temp == null)
            throw new DoesntExistException("does not exist");

        Delete(item.ID);
        Add(item);
    }

    #endregion
    
    /// <summary>
    /// function- returns list of products
    /// </summary>
    /// <returns></returns>
    public IEnumerable<Product?> getAll(Func<Product?, bool>? filter = null)
    {
        if (filter == null)
            return ds.products?.ToList<Product?>() ?? throw new DO.DoesntExistException("Orders list invalid");
        return ds.products.Where(x => filter(x)) ?? throw new DO.DoesntExistException("Orders list invalid"); ;

    }
}