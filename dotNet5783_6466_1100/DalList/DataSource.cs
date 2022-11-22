
using DO;

namespace Dal;

public class DataSource
{
    internal static DataSource s_instance { get; }= new DataSource();// יצירת מופע  נתונים
    private DataSource() { s_initialize(); }
    public readonly Random R = new Random();
    internal  List<Order?> Orders { get; } = new List<Order?> {};
    internal  List<OrderItem?> OrderItems { get; } = new List<OrderItem?>  {};
    internal  List<Product?> products { get; } = new List<Product?>{};
    internal static class Config
    {
        internal const int s_startOrderNumber = 000000;
        private static int s_nextOrderNumber = s_startOrderNumber;
        /// <summary>
        /// function- Update next id
        /// </summary>
        internal static int NextOrderNumber { get => ++s_nextOrderNumber; }
        internal const int s_startOrderItemNumber = 100000;
        private static int s_nextOrderItemNumber = s_startOrderNumber;
        /// <summary>
        /// function- Update next id
        /// </summary>
        internal static int NextOrderItemNumber { get => ++s_nextOrderNumber; }
    }
    #region all add functions
    private void addProduct()
    {
        string[] name = { "Iphone12", "Iphone11", "HeadPhones", "galaxy s22", "galaxy s21", "galaxy s21", " Xiaomi Mi Smart Band Pro", "screen Protector Iphone11", "samsung galaxy Tab 6", "pink cover", "black cover" };
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
                CustomerAdress = adress[R.Next(adress.Length)],
                OrderDate = DateTime.Now - new TimeSpan(R.NextInt64(10L * 1000L * 1000L * 3600L * 24L * 10L)),
                ShipDate = DateTime.Now - new TimeSpan(R.NextInt64(10L * 1000L * 1000L * 3600L * 24L * 10L)),
                DeliveryDate = DateTime.Now - new TimeSpan(R.NextInt64(10L * 1000L * 1000L * 3600L * 24L * 10L))
            };
            Orders.Add(order);
        }
    }

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

    private void s_initialize()
    {
        addProduct();
        addOrder();
        addOrderItem();
    }
}
