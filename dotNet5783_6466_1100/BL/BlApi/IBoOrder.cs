
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;
namespace BlApi;
public interface IBoOrder
{
    public IEnumerable<OrderForList> getOrderForList();
    public Order GetOrder(int ID);
    public Order UpdateShipOrder(int ID);   
    public Order UpdateProvisionOrder(int ID);
    public OrderTracking TrackOrder(int ID);    

    //בונוווסססססס
    public Order UpdateOrder(Product product, int amount);



}
