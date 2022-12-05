using BlApi;

namespace BlImplementation;
internal class BoCart : IBoCart
{
    DalApi.IDal dal = DalApi.Factory.Get() ?? throw new NullReferenceException("Missing Dal");

    public BO.Cart AddProductToCart(BO.Cart cart, int ID)
    {
        throw new NotImplementedException();
    }

    public void MakeCart(BO.Cart cart)
    {
        throw new NotImplementedException();
    }

    public BO.Cart UpdateProductInCart(BO.Cart cart, int ID, int amount)
    {
        throw new NotImplementedException();
    }
}
