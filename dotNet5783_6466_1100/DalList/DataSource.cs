
using DO;

namespace Dal;

public class DataSource
{
    internal static DataSource s_instance { get; }= new DataSource();// create data source
    private DataSource() { s_initialize(); }// ctor for data source
    public readonly Random R = new Random();// random field
    #region create lists
    /// <summary>
    /// list for orders
    /// </summary>
    internal List<Order?> Orders { get; } = new List<Order?> {};
    /// <summary>
    /// list for item orders
    /// </summary>
    internal  List<OrderItem?> OrderItems { get; } = new List<OrderItem?>  {};
    /// <summary>
    /// list for products
    /// </summary>
    internal  List<Product?> products { get; } = new List<Product?>{};
    /// <summary>
    /// class for running number
    /// </summary>
    #endregion
    internal static class Config
    {
        internal const int s_startOrderNumber = 000000;
        private static int s_nextOrderNumber = s_startOrderNumber;
        internal static int NextOrderNumber { get => ++s_nextOrderNumber; }


        internal const int s_startOrderItemNumber = 100000;
        private static int s_nextOrderItemNumber = s_startOrderNumber;
        internal static int NextOrderItemNumber { get => ++s_nextOrderNumber; }
    }
    #region add functions
    /// <summary>
    /// funcion- add products to list of products in data source
    /// </summary>
    private void addProduct()
    {
        string[] name = { "kipa aduma", "tehilim","harry poter1","history book- 8th grage","samech bamitbach", "harry poter2", "harry poter3", "harry poter4", "harry poter5", "harry poter6", "harry poter7" , "ayelet metayelet","pinokiyo","bereshit","shmot","bamidbar", "dvarim"};
        for (int i = 0; i < 10; i++)
        {
            Category category = (Category)R.Next(1, 6);
            products.Add(new Product
            {
                ID = Config.NextOrderNumber,
                Name = name[R.Next(name.Length)],
                Price = R.Next(50, 1500),
                Category = (Category)(i%5),
                InStock = R.Next(0,50)
            });
        }
    }

    /// <summary>
    /// funcion- add orders to list of orders in data source
    /// </summary>
    private void addOrder()
    {
        string[] customerNames = {"sara","rivka","rachel","lea","efrat","miryam","avraham","yaakov","maayan","dani","shir","ori","tamar","reut","yosi" };
        string[] customerEmails = { "miri2451@gmail.com", "efrat@gmail.com", "eli111@gmail.com", "david324@gmail.com", "nurit444@gmail.com", "shoshi234@gmail.com", "yosi878@gmail.com", "yakov656@gmail.com", "liat121@gmail.com", "sason1990@gmail.com" };
        string[] adress = { "Avivim", "Jerusalem", "Tel-Aviv", "Haifa", "Ashdod", "zefat", "beit-El", "Eilat", "Raanana", "Yafo", "Meiron", "Afula", "Arad" };
        for (int i = 0; i < 20; i++)
        {
            Order order = new Order()
            {
                ID = Config.NextOrderNumber,
                CustomerName = customerNames[R.Next(customerNames.Length)],
                CustomerEmail = customerEmails[R.Next(customerEmails.Length)],
                CustomerAddress = adress[R.Next(adress.Length)],
                OrderDate = DateTime.Now - new TimeSpan(R.NextInt64(10L * 1000L * 1000L * 3600L * 24L * 10L)),
                ShipDate = DateTime.Now - new TimeSpan(R.NextInt64(10L * 1000L * 1000L * 3600L * 24L * 10L)),
                DeliveryDate = DateTime.Now - new TimeSpan(R.NextInt64(10L * 1000L * 1000L * 3600L * 24L * 10L))
            };
            Orders.Add(order);
        }
    }

    /// <summary>
    /// funcion- add order items to list of order items in data source
    /// </summary>
    private void addOrderItem()
    {
        string[] customerNames = { "sara", "rivka", "rachel", "lea", "efrat", "miryam", "avraham", "yaakov", "maayan", "dani", "shir", "ori", "tamar", "reut", "yosi" };
        string[] customerEmails = { "miri2451@gmail.com", "efrat@gmail.com", "eli111@gmail.com", "david324@gmail.com", "nurit444@gmail.com", "shoshi234@gmail.com", "yosi878@gmail.com", "yakov656@gmail.com", "liat121@gmail.com", "sason1990@gmail.com" };
        string[] adress = { "Avivim", "Jerusalem", "Tel-Aviv", "Haifa", "Ashdod", "zefat", "beit-El", "Eilat", "Raanana", "Yafo", "Meiron", "Afula", "Arad" };
        for (int i = 0; i < 40; i++)
        {
            OrderItem orderItem = new OrderItem()
            {
                ID = Config.NextOrderNumber,
                ProductID = Config.NextOrderNumber,
                OrderID = Config.NextOrderNumber,
                Price = R.Next(50, 1500),
                Amount = R.Next(1,10) ,

            };
            OrderItems.Add(orderItem);
        }
    }
    #endregion 

    /// <summary>
    /// funcion - initialize data source
    /// </summary>
    private void s_initialize()
    {
        addProduct();
        addOrder();
        addOrderItem();
    }
}
