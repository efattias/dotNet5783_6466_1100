using DalApi;
using DO;
using System.ComponentModel.Design;

namespace Dal;
/// <summary>
/// class for implement the funcions of order product
/// </summary>
public class DalProduct : IProduct
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
            throw new AlreadyExistExeption("המזהה כבר בשימוש");

        if (item.InStock < 0)
            throw new InvalidInputExeption("המלאי אינו יכול להיות שלילי");

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
            throw new DoesntExistException("בלתי ניתן למחיקה- המוצר אינו קיים");
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
            throw new DoesntExistException("המוצר אינו קיים");

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
            throw new DoesntExistException("המוצר אינו קיים");

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
            return ds.products?.ToList<Product?>() ?? throw new DO.DoesntExistException("רשימת המוצרים אינה חוקית");
        return (List<Product?>)(ds.products.Where(x => filter(x)) ?? throw new DO.DoesntExistException("רשימת המוצרים אינה חוקית")); ;

    }


    public Product? getByFilter(Func<Product?, bool>? filter)
    {
        var product = ds.products.Where(x => filter(x)) ?? throw new DoesntExistException("המוצר לפי הסינון אינו קיים");
        return product.First();
    }
}