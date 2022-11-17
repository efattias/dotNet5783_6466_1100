

using DO;

namespace Dal;

internal static class DataSource
{
    internal readonly static Random R = new Random();
    internal static List<Order> Orders = new();
    internal static List<OrderItem> OrderItems = new();
    internal static List<Product> products = new();

    private static void addProduct()
    {
        string[] name = { "Iphone12", "HeadPhones", "galaxy s22", "galaxy s21", "galaxy s21", " Xiaomi Mi Smart Band Pro", "screen Protector Iphone11", "samsung galaxy Tab 6" };
        for (int i = 0; i < 10; i++)
        {
            Product product = new Product()
            {
                ID = R.Next(000000, 999999),
                
                Price = R.Next(50,1500),
             //   Category=

            

            };
        }
    }

    private static void addOrder()
    {

    }
  
}
