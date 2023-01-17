using BlApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PL;

public static class Tools
{
    public static Target CopyPropTo<Source, Target>(this Source source, Target target)
    {

        if (source is not null && target is not null)
        {
            Dictionary<string, PropertyInfo> propertiesInfoTarget = target.GetType().GetProperties()
                .ToDictionary(p => p.Name, p => p);

            IEnumerable<PropertyInfo> propertiesInfoSource = source.GetType().GetProperties();

            foreach (var propertyInfo in propertiesInfoSource)
            {
                if (propertiesInfoTarget.ContainsKey(propertyInfo.Name)
                    && (propertyInfo.PropertyType == typeof(string) || !propertyInfo.PropertyType.IsClass))
                {
                    propertiesInfoTarget[propertyInfo.Name].SetValue(target, propertyInfo.GetValue(source));
                }
            }
        }
        return target;
    }
    public static IBL bl = Factory.GetBl();
    public static PO.CartPO BoTOPoCart(this BO.Cart cartBO)
    {
        PO.CartPO cartPO = new PO.CartPO();
        cartPO.Items = new();
        CopyPropTo(cartBO,cartPO);
        if (cartPO.Items != null)
            foreach (var item in cartBO.Items)
                cartPO.Items.Add(CopyPropTo(item, new PO.OrderItemPO()));
        return cartPO;
        //    {
        //        CustomerAddress = cartBO.CustomerAddress,
        //        CustomerName = cartBO.CustomerName,
        //        CustomerEmail = cartBO.CustomerEmail,
        //        TotalPrice = (double)cartBO.TotalPrice

        //    };
        //    cartPO.Items = new();
        //    var listPO = (from p in cartBO.Items
        //                  select new PO.OrderItemPO
        //                  {
        //                      ID = p.ID,
        //                      Price = (double)p.Price,
        //                      ProductID = p.ProductID,
        //                      TotalPrice = (double)p.TotalPrice,
        //                      Amount = (double)p.Amount,
        //                      Name = p.Name

        //                  }).ToList();
        //   cartPO.Items.Clear();
        //    foreach (var p in listPO)
        //        cartPO.Items.Add(p);
        //    return cartPO;
        //}
        
    }
}
