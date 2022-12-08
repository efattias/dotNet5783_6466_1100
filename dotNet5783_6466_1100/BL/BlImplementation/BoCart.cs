using BlApi;
using BO;

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
                temp!.Name = productDO?.Name;
                temp!.ProductID = (int)(productDO?.ID!);
                temp!.Price = productDO?.Price;
                temp.Amount = 1;
                temp.TotalPrice = productDO?.Price;
                cart?.Items?.Add(temp);
                cart!.TotalPrice = Tools.GetTotalPrice((IEnumerable<DO.OrderItem>)(cart?.Items!));
            }
        }// אוצפיה:להעביר לעגלה חדשה ולשנות במקרה הספציפי
        else//////// לא עובדדדדדדדדדדדדדד- לבדוק איך לדחוף לעגלה
        {
           if (productDO != null && productDO?.InStock > 0)
            {
                temp.Amount += 1;
                temp.TotalPrice = temp.Price * temp.Amount;
                cart!.TotalPrice = Tools.GetTotalPrice((IEnumerable<DO.OrderItem>)(cart?.Items!));
            }

        }
    }

    public void MakeCart(BO.Cart? cart)
    {
        throw new NotImplementedException();
    }

    public BO.Cart UpdateProductInCart(BO.Cart? cart, int ID, int amount)
    {
        throw new NotImplementedException();
    }
}
