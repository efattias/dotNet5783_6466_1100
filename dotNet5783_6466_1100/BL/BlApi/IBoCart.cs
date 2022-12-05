
using BO;
namespace BlApi;
public interface IBoCart
{
    public Cart AddProductToCart(Cart cart, int ID);
    public Cart UpdateProductInCart(Cart cart, int ID, int amount);
    public void MakeCart(Cart cart);    
}
