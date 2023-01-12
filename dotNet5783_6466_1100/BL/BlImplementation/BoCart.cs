using BlApi;
using BO;

namespace BlImplementation;

internal class BoCart : IBoCart
{
    DalApi.IDal? dal = DalApi.Factory.Get() ?? throw new NullReferenceException("שכבת הגישה לנתונים חסרה");

    public BO.Cart? AddProductToCart(BO.Cart? cart, int ID)
    {
        try
        {
            if (cart == null)
                cart = new BO.Cart();

            DO.Product? productDO = dal!.Product.GetByID(ID);// find the product if exists
            BO.OrderItem? temp = cart?.Items?.Find(x => x?.ProductID == productDO?.ID);// search in cart

            if (temp == null)//item  does not in cart
            {
                if (productDO != null && productDO?.InStock > 0)
                {
                    BO.OrderItem ItemToReturn = new BO.OrderItem()
                    {
                        ID = 0,
                        Name = productDO?.Name,
                        ProductID = (int)(productDO?.ID!),
                        Price = productDO?.Price,
                        Amount = 1,
                        TotalPrice = productDO?.Price,
                    };
                    cart?.Items?.Add(ItemToReturn);
                    cart!.TotalPrice = Tools.GetTotalPriceBO((cart?.Items!));
                }
                else
                if (productDO?.InStock <= 0)
                    throw new BO.ProductOutOfStockException("המוצר אזל מהמלאי");
            }
            else
            {
                if (temp?.Amount >= productDO?.InStock)
                    throw new BO.ProductOutOfStockException("המוצר אזל מהמלאי");

                temp!.Amount++;
                temp!.TotalPrice += temp!.Price;
                cart!.TotalPrice += temp!.Price;
            }
        }
        catch (DO.DoesntExistException ex)
        {
            throw new BO.DoesntExistException(ex.Message, ex);
        }
        catch (BO.ProductOutOfStockException ex)
        {
            throw new BO.ProductOutOfStockException(ex.Message, ex);
        }

        return cart;
    }


    public void MakeCart(BO.Cart? cart)
    {
        try
        {
            //testing
            if (!((bool)(cart!.CustomerEmail!.Contains('@'))) || (!((bool)(cart.CustomerEmail.Contains('.')))))
                throw new BO.InvalidInputExeption("כתובת הדואר האלקטרוני אינו נכתב נכון");

            if (cart?.CustomerEmail == null)
                throw new BO.DoesntExistException("כתובת הדואר האלקטרוני חסרה");

            if (cart?.CustomerAddress == null)
                throw new BO.DoesntExistException("כתובת לקוח חסרה");

            if (cart?.CustomerName == null)
                throw new BO.DoesntExistException("שם לקוח חסר");

            if (cart?.TotalPrice < 0)
                throw new BO.InvalidInputExeption("המחיר הסופי מחוץ לתחום");

            List<BO.OrderItem> itemList = new List<BO.OrderItem>();

            foreach (BO.OrderItem? o in cart?.Items!)
            {
                DO.Product prodectDO = dal!.Product.GetByID(o!.ProductID);

                if (prodectDO.InStock < o?.Amount)
                    throw new BO.ProductOutOfStockException("המוצר אזל מהמלאי -לא יכול להיות בעגלה");

                if (o?.TotalPrice < 0 || o?.Price < 0 || o?.Amount < 0 || o?.ID < 0 || (!(o?.ProductID >= 100000 && o?.ProductID < 1000000)))
                    throw new BO.InvalidInputExeption("אחד הפרטים ברשימת הפריטים בהזמנה אינו בטווח");

                itemList.Add(o);
            }

            DO.Order orderToReturn = new DO.Order()// create the new order
            {
                ID = 0,
                CustomerAddress = cart?.CustomerAddress,
                CustomerEmail = cart?.CustomerEmail,
                CustomerName = cart?.CustomerName,
                DeliveryDate = null,
                ShipDate = null,
                OrderDate = DateTime.Now,
            };
            int idNewOrder = dal!.Order.Add(orderToReturn);

            foreach (BO.OrderItem? item in itemList)
            {
                DO.Product productDO = dal.Product.GetByID(item!.ProductID);
                DO.OrderItem orderItemToUpdate = new DO.OrderItem();

                orderItemToUpdate.ID = item.ID;
                orderItemToUpdate.ProductID = productDO.ID;
                orderItemToUpdate = (DO.OrderItem)Tools.CopyPropToStruct(item, typeof(DO.OrderItem));
                orderItemToUpdate.OrderID = idNewOrder;
                dal.OrderItem.Add(orderItemToUpdate);
                productDO.InStock -= item.Amount;
                dal.Product.Update(productDO);
            }
        }
        catch (DO.AlreadyExistExeption ex)
        {
            throw new BO.DoesntExistException(ex.Message, ex);
        }

        catch (BO.InvalidInputExeption ex)
        {
            throw new BO.InvalidInputExeption(ex.Message, ex);
        }

        catch (BO.ProductOutOfStockException ex)
        {
            throw new BO.ProductOutOfStockException(ex.Message, ex);
        }
    }

    public BO.Cart UpdateProductInCart(BO.Cart? cart, int ID, int amount)
    {
        try
        {
            DO.Product? p = dal!.Product.GetByID(ID);

            if (cart?.Items == null)
                throw new BO.DoesntExistException("הסל ריק");

            foreach (BO.OrderItem? item in cart.Items)
            {
                if (item != null && item.ProductID == ID)
                {
                    if (amount == 0)
                    {
                        cart.Items.Remove(item);
                        cart.TotalPrice = cart.TotalPrice ?? 0 - (item.Price * item.Amount);
                        cart.TotalPrice = Math.Round(cart.TotalPrice ?? 0, 2);
                        return cart;
                    }

                    int? difference = amount - item.Amount;

                    if (item.Amount < amount)
                    {
                        if (!(p?.InStock >= difference))
                            throw new BO.ProductOutOfStockException("בלתי אפשרי להוספה- המוצר אזל מהמלאי");

                        item.Amount = amount;
                        cart.TotalPrice = (cart.TotalPrice ?? 0) + (item.Price * difference);
                        cart.TotalPrice = Math.Round(cart.TotalPrice ?? 0, 2);
                        return cart;
                    }

                    if (item.Amount > amount)
                    {
                        item.Amount = amount;
                        cart.TotalPrice = (cart.TotalPrice ?? 0) + (item.Price * difference);
                        cart.TotalPrice = Math.Round(cart.TotalPrice ?? 0, 2);
                        return cart;
                    }
                }
            }
            return cart;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}