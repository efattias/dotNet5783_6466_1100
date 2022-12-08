
using BO;
using DalApi;
using System.Reflection;

namespace BlApi;

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
    public static int GetAmountOfItems(IEnumerable<DO.OrderItem> orderFromBL)
    {
        int? sum = 0;   
        foreach(DO.OrderItem o in orderFromBL)
        {
            sum = sum +o.Amount;
        }
        return (int)sum;     
    }
    public static double GetTotalPrice(IEnumerable<DO.OrderItem> ListItems)
    {
        double? total = 0;
        foreach (DO.OrderItem o in ListItems)
        {
            total = total + o.Price*o.Amount;
        }
        return (int)total;
    }
   
}
