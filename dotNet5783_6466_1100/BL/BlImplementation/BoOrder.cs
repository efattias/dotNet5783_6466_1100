using BlApi;


namespace BlImplementation;
internal class BoOrder:IBoOrder
{
   
    DalApi.IDal dal = DalApi.Factory.Get() ?? throw new NullReferenceException("Missing Dal");

    public BO.Order GetOrder(int ID)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<BO.OrderForList> getOrderForList()
    {
        throw new NotImplementedException();
    }

    public BO.OrderTracking TrackOrder(int ID)
    {
        throw new NotImplementedException();
    }

    public BO.Order UpdateOrder(BO.Product product, int amount)
    {
        throw new NotImplementedException();
    }

    public BO.Order UpdateProvisionOrder(int ID)
    {
        throw new NotImplementedException();
    }

    public BO.Order UpdateShipOrder(int ID)
    {
        throw new NotImplementedException();
    }
}
