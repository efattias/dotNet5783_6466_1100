
using BO;
using DalApi;
using System.Reflection;
using System.Collections;
using DO;
using System.Diagnostics;

namespace BlApi;

public static class Tools
{
    
    //DO to BO
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
    // BO to DO
    public static object CopyPropToStruct<S>(this S from, Type type)//get the type we want to copy to 
    {
        object copy = Activator.CreateInstance(type); // new object of the Type
        from.CopyPropTo(copy);//copy all value of properties with the same name to the new object
        return copy!;
    }

    public static Status GetStatus(DO.Order order)
    {  
        if (order.DeliveryDate != null && order.DeliveryDate < DateTime.Now)
            return Status.provided;
        else if (order.ShipDate != null && order.ShipDate < DateTime.Now)
            return Status.sent;
        else if (order.OrderDate != null && order.OrderDate < DateTime.Now)
            return Status.approved;
        else
            return Status.none;
        
    }
    public static int GetAmountOfItems(IEnumerable<DO.OrderItem?> orderFromBL)
    {
        int? sum = 0;   
        foreach(DO.OrderItem? o in orderFromBL)
        {
            sum = sum +o?.Amount;
        }
        return (int)sum;     
    }
    public static double GetTotalPrice(IEnumerable<DO.OrderItem?> ListItems)
    {
        double? total = 0;
        foreach (DO.OrderItem? o in ListItems)
        {
            total = total + o?.Price*o?.Amount;
        }
        return (int)total;
    }
    public static double GetTotalPriceBO(IEnumerable<BO.OrderItem?> ListItems)
    {
        double? total = 0;
        foreach (BO.OrderItem? o in ListItems)
        {
            total = total + o?.Price * o?.Amount;
        }
        return (int)total;
    }
    public static IEnumerable<BO.OrderItem?> getBOList(IEnumerable<DO.OrderItem?> ListItems)
    {
        return (
        from o in ListItems
       
        select new BO.OrderItem
        {
          
            ID = (int)(o?.ID!),
            ProductID = (int)(o?.ProductID!),
            Price = o?.Price,
            Amount = o?.Amount,
            TotalPrice = o?.Price * o?.Amount
        }).ToList();
    }
    public static string ToStringProperty<T>(this T t, string suffix = "")
    //מתודה להפיכת ישות למחרוזת לצורך הצגת הפרטים
    {
        string str = "";
        foreach (PropertyInfo prop in t!.GetType().GetProperties())
        {
            var value = prop.GetValue(t, null);
            if (value is not string && value is IEnumerable)
            {
                str = str + "\n" + prop.Name + ":";
                foreach (var item in (IEnumerable)value)
                    str += item.ToStringProperty("      ");
            }

            else
                str += "\n" + suffix + prop.Name + ": " + value;
        }
        str += "\n";
        return str;
    }
   public static bool inStock(int inStock)
    {
        if (inStock>0)
            return true;
        return false;
    }
    public static int getAmountOfProduct(List<BO.OrderItem> orderItemsList,int productId)
    {
         BO.OrderItem ? temp = orderItemsList.Find(x => x?.ProductID == productId);
        if (temp != null)
        {
            return (int)temp?.Amount!;
        }
        return 0;

    }
}
