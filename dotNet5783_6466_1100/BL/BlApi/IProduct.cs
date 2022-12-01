using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;
namespace BlApi;
public interface IProduct
{
    public IEnumerable<ProductForList> getProductForList();
    public Product GetProduct(int ID);
    public ProductItem GetProduct(int ID,Cart cart);
    public void AddProduct(Product product);    
    public void DeledeProduct(int ID);
    public void UpdateDetailProduct(Product product);
}
