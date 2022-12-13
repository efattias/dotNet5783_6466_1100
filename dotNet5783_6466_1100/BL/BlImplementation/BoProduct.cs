using BlApi;

namespace BlImplementation;

internal class BoProduct :IBoProduct
{
    DalApi.IDal dal = DalApi.Factory.Get() ?? throw new NullReferenceException("Missing Dal");
    /// <summary>
    /// function- adding product to Dal
    /// </summary>
    /// <param name="product"></param>
    /// <exception cref="BO.InvalidInputExeption"></exception>
    /// <exception cref="BO.AlreadyExistExeption"></exception>
    public void AddProduct(BO.Product? product)
    {
        if (!(product?.ID >= 100000 && product?.ID < 1000000))// id test
            throw new BO.InvalidInputExeption("ID is out of range");

        if (product?.Name == "")// name test 
            throw new BO.InvalidInputExeption("Name is not correct");

        if (product?.Price <= 0)// price test
            throw new BO.InvalidInputExeption("Price is out of range");

        if (product?.InStock < 0)// stock test
            throw new BO.InvalidInputExeption("Product is out of stock");
        try
        {
            DO.Product productTempDO = new DO.Product()// create DO product to enter the DAL
            {
                ID = product!.ID,
                Name = product?.Name,
                Price = product?.Price,
                Category = (DO.Category?)product?.Category,
                InStock = product?.InStock
            };
            dal.Product.Add(productTempDO); // adding
        }
        catch (DO.AlreadyExistExeption ex)// if doesnt work catch exeption
        {
            throw new BO.AlreadyExistExeption(ex.Message, ex);
        } 
    }
    /// <summary>
    /// function- delete product from DAL
    /// </summary>
    /// <param name="IDProduct"></param>
    /// <exception cref="BO.DoesntExistException"></exception>
    /// <exception cref="CantDeleteItem"></exception>
    public void DeledeProduct(int IDProduct)
    {
        bool flag = true;
        List<DO.Order?> tempList = (List<DO.Order?>)dal.Order.getAll();// create temp list 
        foreach (DO.Order? o in tempList)// go over the list
        {
            DO.OrderItem? item = new DO.OrderItem();// create orderItem for testing
            try
            {
                item = dal.OrderItem.GetProductByOrderAndID((int)(o?.ID!), IDProduct);// search the product in orders

                if (item != null)// if the product exists
                {
                    flag = false;
                    throw new BO.CantDeleteItemException("Product exists in order - can not delete");
                }
            }
            catch (DO.DoesntExistException ex)
            {
            
                //throw new BO.DoesntExistException(ex.Message, ex);
            }
        }
        try
        {
            if (flag)
            dal.Product.Delete(IDProduct); // deleting
        }
        catch (DO.DoesntExistException ex)// if doesnt work catch exeption
        {
            throw new BO.DoesntExistException(ex.Message, ex);
        }
    }
    /// <summary>
    /// funcion- returns product from DAL by ID
    /// </summary>
    /// <param name="ID"></param>
    /// <returns></returns>
    /// <exception cref="InvalidInputExeption"></exception>
    /// <exception cref="BO.DoesntExistException"></exception>
    public BO.Product? GetProductbyId(int ID)
    {
        if(ID < 0)// test id
            throw new BO.InvalidInputExeption("ID is out of range");
        
        try
        {
            BO.Product productTempBO = new BO.Product();// create BO product
            DO.Product productTempDO = dal.Product.GetByID(ID);// create DO product
            // copy details
            productTempBO.ID = productTempDO.ID;
            productTempBO.Name = productTempDO.Name;
            productTempBO.Price = productTempDO.Price;
            productTempBO.Category = (BO.Category?)productTempDO.Category;
            productTempBO.InStock = productTempDO.InStock;

            return productTempBO;// return the product
        }
        catch(DO.DoesntExistException ex)
        {
            throw new BO.DoesntExistException(ex.Message, ex);
        }  
    }

    public BO.ProductItem GetProductByIDAndCart(int ID, BO.Cart? cart)
    {
        if (ID<0)
            throw new BO.InvalidInputExeption("id is out of range");
        
        try
        {
            DO.Product? productTempDO = dal.Product.GetByID(ID);
            BO.ProductItem productItemBO = new BO.ProductItem()
            {
                ID = (int)(productTempDO?.ID!),
                Name = productTempDO?.Name,
                Price = productTempDO?.Price,
                Category = (BO.Category?)productTempDO?.Category,
                InStock = Tools.inStock((int)productTempDO?.InStock!),
                Amount = Tools.getAmountOfProduct( cart?.Items!, (int)(productTempDO?.ID!))
            };
            return productItemBO;

        }
        catch (DO.DoesntExistException ex)
        {
            throw new BO.DoesntExistException(ex.Message, ex);
        }
    }
    /// <summary>
    /// function- returns list of ProductForList 
    /// </summary>
    /// <returns></returns>
    public IEnumerable<BO.ProductForList> getProductForList()
    {
        List<DO.Product?> productListDO = (List<DO.Product?>)dal.Product.getAll();

        return (from p in productListDO
                let productFromBL = GetProductbyId((int)(p?.ID!))
                select new BO.ProductForList()
                {
                    ID = (int)(p?.ID!),
                    Name = p?.Name,
                    Price = p?.Price,
                    Category = (BO.Category?)p?.Category
                }).ToList();
    }
    public void UpdateDetailProduct(BO.Product? product)
    {
        if (!(product?.ID >= 100000 && product?.ID < 1000000))// id test
            throw new BO.InvalidInputExeption("ID is out of range");

        if (product?.Name == "")// name test 
            throw new BO.InvalidInputExeption("Name is not correct");

        if (product?.Price <= 0)// price test
            throw new BO.InvalidInputExeption("Price is out of range");

        if (product?.InStock < 0)// stock test
            throw new BO.InvalidInputExeption("Product is out of stock");

        try
        {
            DO.Product productTempDO = new DO.Product()// create DO product to update in DAL
            {
                ID = product!.ID,
                Name = product?.Name,
                Price = product?.Price,
                Category = (DO.Category?)product?.Category,
                InStock = product?.InStock
            };

            dal.Product.Update(productTempDO); // updating
        }
        catch (DO.DoesntExistException ex)// if doesnt work catch exeption
        {
            throw new BO.DoesntExistException(ex.Message, ex);
        }
    }
}
