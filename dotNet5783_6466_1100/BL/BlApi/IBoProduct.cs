using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BlApi;
public interface IBoProduct
{
    public IEnumerable<BO.ProductForList> getProductForList();
    public BO.Product? GetProductbyId(int ID);
    public BO.ProductItem GetProductByIDAndCart(int ID,BO.Cart? cart);
    public void AddProduct(BO.Product? product);    
    public void DeledeProduct(int ID);
    public void UpdateDetailProduct(BO.Product? product);
    public IEnumerable<ProductForList> GetPartOfProduct(Predicate<ProductForList> check);
}
