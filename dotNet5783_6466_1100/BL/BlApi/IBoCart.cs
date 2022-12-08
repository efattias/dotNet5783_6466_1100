﻿
namespace BlApi;
public interface IBoCart
{
    public BO.Cart? AddProductToCart(BO.Cart? cart, int ID);
    public BO.Cart UpdateProductInCart(BO.Cart? cart, int ID, int amount);
    public void MakeCart(BO.Cart? cart);    
}
