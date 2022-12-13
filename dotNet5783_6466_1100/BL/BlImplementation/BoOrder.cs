using BlApi;


namespace BlImplementation;
internal class BoOrder : IBoOrder
{

    DalApi.IDal dal = DalApi.Factory.Get() ?? throw new NullReferenceException("Missing Dal");

    public BO.Order GetOrder(int ID)
    {
        if (ID < 0)// test id
            throw new BO.InvalidInputExeption("ID is out of range");
        
        try
        {
            List<DO.Order?> orderListDO = (List<DO.Order?>)dal.Order.getAll();
            BO.Order orderTempBO = new BO.Order();// create BO Order list
            DO.Order orderTempDO = dal.Order.GetByID(ID);// create DO Order list
            IEnumerable<DO.OrderItem?> itemsListDO = dal.OrderItem.GetItemsList(orderTempDO.ID);                                            // copy details
            orderTempBO.ID = orderTempDO.ID;
            orderTempBO.CustomerName = orderTempDO.CustomerName;
            orderTempBO.CustomerEmail = orderTempDO.CustomerEmail;
            orderTempBO.CustomerAddress = orderTempDO.CustomerAddress;
            orderTempBO.OrderStatus = BlApi.Tools.GetStatus(orderTempDO);
            orderTempBO.OrderDate = orderTempDO.OrderDate;
            orderTempBO.ShipDate = orderTempDO.ShipDate;
            orderTempBO.DeliveryDate = orderTempDO.DeliveryDate;
            orderTempBO.Items = (List<BO.OrderItem?>)Tools.getBOList(itemsListDO!);
            orderTempBO.TotalPrice = BlApi.Tools.GetTotalPrice(itemsListDO!);

            return orderTempBO;// return the order
        }
        catch (DO.DoesntExistException ex)
        {
            throw new BO.DoesntExistException(ex.Message, ex);
        }
    }

    public IEnumerable<BO.OrderForList?> getOrderForList()
    {
        List<DO.Order?> orderListDO = (List<DO.Order?>)dal.Order.getAll();

        BO.OrderForList orderForListTemp = new BO.OrderForList();

        return
            (from orderDO in orderListDO
             let orderFromBL = dal.OrderItem.GetItemsList((int)(orderDO?.ID!))
             select new BO.OrderForList()
             {
                 ID = (int)(orderDO?.ID!),
                 CustomerName = orderDO?.CustomerName,
                 OrderStatus = Tools.GetStatus((DO.Order)orderDO),
                 AmountOfItems = Tools.GetAmountOfItems(orderFromBL),
                 TotalPrice = Tools.GetTotalPrice(orderFromBL)
             }).ToList();
    }

    public BO.OrderTracking TrackOrder(int ID)
    {
        if (ID < 0)
            throw new BO.InvalidInputExeption("id is not in range");
        
        try
        {
            DO.Order orderDO = dal.Order.GetByID(ID);// הזמנה מ DO
            List<Tuple<DateTime?, string>>? tempTrackList = new List<Tuple<DateTime?, string>>();// רשימת צמדים

            if (orderDO.OrderDate != null)
            {
                tempTrackList.Add(Tuple.Create(orderDO.OrderDate, "order created"));
                if (orderDO.ShipDate != null)
                {
                    tempTrackList.Add(Tuple.Create(orderDO.ShipDate, "order sent"));
                    if (orderDO.DeliveryDate != null)
                    {
                        tempTrackList.Add(Tuple.Create(orderDO.DeliveryDate, "order provided"));
                    }
                }
            }
            BO.OrderTracking orderTracking = new BO.OrderTracking()
            {
                ID = orderDO.ID,
                OrderStatus = BlApi.Tools.GetStatus(orderDO),
                trackList = tempTrackList
            };
            return orderTracking;
        }
        catch (DO.DoesntExistException ex)
        {
            throw new BO.DoesntExistException(ex.Message, ex);
        }
    }


    //public BO.Order UpdateOrder(BO.Product product, int amount)
    //{
    //    throw new NotImplementedException();
    //}

    public BO.Order UpdateProvisionOrder(int ID)
    {
        if (ID < 0)
            throw new BO.InvalidInputExeption("id is out of range");
        
        try
        {
            DO.Order orderDO = dal.Order.GetByID(ID);
            IEnumerable<DO.OrderItem?>? itemsListDO = dal.OrderItem.GetItemsList(orderDO.ID);                                            // copy details

            if (orderDO.DeliveryDate != null && orderDO.DeliveryDate < DateTime.Now)
            {
                orderDO.DeliveryDate = DateTime.Now;
                dal.Order.Update(orderDO);
            }
            BO.Order orderToReturn = new BO.Order()
            {
                ID = orderDO.ID,
                CustomerName = orderDO.CustomerName,
                CustomerEmail = orderDO.CustomerEmail,
                CustomerAddress = orderDO.CustomerAddress,
                OrderStatus = BlApi.Tools.GetStatus(orderDO),
                OrderDate = orderDO.OrderDate,
                ShipDate = orderDO.ShipDate,
                DeliveryDate = orderDO.DeliveryDate,
                Items = (List<BO.OrderItem?>)dal.OrderItem.GetItemsList(orderDO.ID),
                TotalPrice = BlApi.Tools.GetTotalPrice(itemsListDO!)
            };
            return orderToReturn;
        }
        catch (DO.DoesntExistException ex)
        {
            throw new BO.DoesntExistException(ex.Message, ex);
        }
    }
    public BO.Order UpdateShipOrder(int ID)
    {
        if (ID<0)
            throw new BO.InvalidInputExeption("id is out of range");
        
        try
        {
            DO.Order orderDO = dal.Order.GetByID(ID);
            IEnumerable<DO.OrderItem?> itemsListDO = dal.OrderItem.GetItemsList(orderDO.ID);                                            // copy details

            if (orderDO.ShipDate != null && orderDO.ShipDate < DateTime.Now)
            {
                orderDO.ShipDate = DateTime.Now;
                dal.Order.Update(orderDO);
            }
            BO.Order orderToReturn = new BO.Order()
            {
                ID = orderDO.ID,
                CustomerName = orderDO.CustomerName,
                CustomerEmail = orderDO.CustomerEmail,
                CustomerAddress = orderDO.CustomerAddress,
                OrderStatus = BlApi.Tools.GetStatus(orderDO),
                OrderDate = orderDO.OrderDate,
                ShipDate = orderDO.ShipDate,
                DeliveryDate = orderDO.DeliveryDate,
                Items = (List<BO.OrderItem?>)Tools.getBOList(dal.OrderItem.GetItemsList(orderDO.ID)),
                TotalPrice = Tools.GetTotalPrice(itemsListDO!)
            };
            return orderToReturn;
        }
        catch (DO.DoesntExistException ex)
        {
            throw new BO.DoesntExistException(ex.Message, ex);
        }
    }
}
