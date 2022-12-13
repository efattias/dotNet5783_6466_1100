using BlApi;
using BO;
using DO;

namespace BlImplementation;
internal class BoCart : IBoCart
{
    DalApi.IDal dal = DalApi.Factory.Get() ?? throw new NullReferenceException("Missing Dal");

    public BO.Cart? AddProductToCart(BO.Cart? cart, int ID)
    {
        DO.Product? productDO = dal.Product.GetByID(ID);
        BO.OrderItem? temp = cart?.Items?.Find(x => x?.ProductID == productDO?.ID);
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
        }// אוצפיה:להעביר לעגלה חדשה ולשנות במקרה הספציפי
        else//////// לא עובדדדדדדדדדדדדדד- לבדוק איך לדחוף לעגלה
        {
           if (productDO != null && productDO?.InStock > 0)
            {
                foreach(BO.OrderItem? o in cart?.Items!)
                {
                    if(o?.Name==productDO?.Name)
                    {
                        o!.Amount += 1;
                        temp.TotalPrice = temp.Price * temp.Amount;

                    }
                }
                cart!.TotalPrice = Tools.GetTotalPrice((IEnumerable<DO.OrderItem?>)(cart?.Items!));
            }

        }
        return cart;
    }

    public void MakeCart(BO.Cart? cart)
    {
        //testing
        if (!((bool)(cart?.CustomerEmail.Contains('@'))) || (!((bool)(cart?.CustomerEmail.Contains('.')))))
            throw new BO.InvalidInputExeption("email is not writen good");
        if (cart?.CustomerEmail == null)
            throw new BO.DoesntExistException("email adress is missing");
        if (cart?.CustomerAddress == null)
            throw new BO.DoesntExistException("costumer addres missing");
        if (cart?.CustomerName == null)
            throw new BO.DoesntExistException("costumer addres missing");
        if (cart?.TotalPrice < 0)
            throw new BO.InvalidInputExeption("total price is out of range");
        foreach(BO.OrderItem? o in cart?.Items!)
        {
         // לבדוק איך פרודקט קיים
            if (o?.TotalPrice < 0||o?.Price<0 || o?.Amount < 0 || o?.ID < 0 || (!(o?.ProductID >= 100000 && o?.ProductID < 1000000)))
                throw new BO.InvalidInputExeption("one of the details in orderItem list is out of range");
            if (o?.Name == null)
                throw new BO.InvalidInputExeption("name is missing");
        }
        BO.Order orderToReturn = new BO.Order()
        {
            ID = 0,
            CustomerAddress = cart?.CustomerAddress,
            CustomerEmail = cart?.CustomerEmail,
            CustomerName = cart?.CustomerName,
            OrderStatus = Status.approved,
            DeliveryDate = null,
            ShipDate = null,
            OrderDate = DateTime.Now,
            Items = (List<BO.OrderItem?>)Tools.getBOList((IEnumerable<DO.OrderItem?>)(cart?.Items!)),
            TotalPrice = cart?.TotalPrice
        };///////////////// לסייםםםםםם

    }

    public BO.Cart UpdateProductInCart(BO.Cart? cart, int ID, int amount)
    {
        throw new NotImplementedException();
    }
}
