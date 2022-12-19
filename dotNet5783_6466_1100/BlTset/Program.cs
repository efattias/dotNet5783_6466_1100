using BlApi;
using BlImplementation;
using BO;
using Dal;
using DalApi;
using DO;
using System.Diagnostics;

namespace BlTset;

internal class Program
{
    static IBL bl = new Bl();
    static Cart? cart = new Cart() { CustomerAddress = "", CustomerEmail = "", CustomerName = "", Items = new List<BO.OrderItem?>(), TotalPrice = 0 };
    static void TestBoProduct()
    {

        int choice = 1;

        while (choice != 0)
        {
            try
            {
                Console.WriteLine("Enter your choice:\n" +
                    "0-exit\n" +
                    "1-add product\n" +
                    "2-get product by ID\n" +
                    "3-get product by ID and cart\n" +
                    "4-get product list \n" +
                    "5-update product\n" +
                    "6-delete product\n");
                bool flag = int.TryParse(Console.ReadLine(), out choice);

                BO.Product temp = new BO.Product();
                int id;

                switch (choice)
                {
                    case 1:
                        #region case 1
                        /*Console.WriteLine("insert product details:");

                        Console.WriteLine("id:");
                        int.TryParse(Console.ReadLine(), out detail);
                        temp.ID = detail;

                        Console.WriteLine("name:");
                        n = Console.ReadLine();
                        temp.Name = n;

                        Console.WriteLine("price:");
                        double.TryParse(Console.ReadLine(), out price);
                        temp.Price = price;

                        Console.WriteLine(@"choose product catgory: 
                                        0-kids books, 
                                        1-teens books, 
                                        2-cook books, 
                                        3-kodesh books, 
                                        4-learning books");

                        int.TryParse(Console.ReadLine(), out cat);

                        switch (cat)
                        {
                            case 0:
                                temp.Category = BO.Category.kids;
                                break;
                            case 1:
                                temp.Category = BO.Category.teens;
                                break;
                            case 2:
                                temp.Category = BO.Category.cook;
                                break;
                            case 3:
                                temp.Category = BO.Category.kodesh;
                                break;
                            case 4:
                                temp.Category = BO.Category.learn;
                                break;
                            default:
                                Console.WriteLine("ERROR- category does not exist");
                                break;
                        }

                        Console.WriteLine("product in stock:");
                        int.TryParse(Console.ReadLine(), out detail);
                        temp.InStock = detail;*/
                        InsertProductDetails(ref temp);
                        bl.Product.AddProduct(temp);
                        #endregion
                        break;
                    case 2:
                        #region case 2
                        Console.WriteLine("insert id to get product:");
                        int.TryParse(Console.ReadLine(), out id);

                        Console.WriteLine(bl.Product.GetProductbyId(id));
                        #endregion
                        break;
                    case 3:
                        #region case 3
                        Console.WriteLine("insert id to get product:");
                        int.TryParse(Console.ReadLine(), out id);

                        Console.WriteLine(bl.Product.GetProductByIDAndCart(id, cart));
                        #endregion
                        break;
                    case 4:
                        #region case 4
                        var p = bl.Product.getProductForList();
                        foreach (var item in p)
                            Console.WriteLine(item.ToString());
                        #endregion
                        break;
                    case 5:
                        #region case 5
                        InsertProductDetails(ref temp);
                        bl.Product.UpdateDetailProduct(temp);
                        #endregion
                        break;
                    case 6:
                        #region case 6
                        Console.WriteLine("insert id to delete product:");
                        int.TryParse(Console.ReadLine(), out id);

                        bl.Product.DeledeProduct(id);
                        #endregion
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("ERROR- your choice does not exist");
                        break;
                }
                if (choice == 0)
                    break;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }


    static void TestBoCart()
    {
        int choice = 1;

        while (choice != 0)
        {
            try
            {
                Console.WriteLine("Enter your choice:\n" +
                "0-exit\n" +
                "1-add product to cart\n" +
                "2-update product in cart\n" +
                "3-make order by this cart\n");

                bool flag = int.TryParse(Console.ReadLine(), out choice);
                int id;
                int amount;
                // string? name;

                switch (choice)
                {
                    case 1:
                        #region case 1
                        Console.WriteLine("insert product id to add cart:");
                        int.TryParse(Console.ReadLine(), out id);

                        cart = bl.cart.AddProductToCart(cart, id);
                        #endregion
                        break;
                    case 2:
                        #region case 2
                        Console.WriteLine("insert product id to add cart:");
                        int.TryParse(Console.ReadLine(), out id);

                        Console.WriteLine("insert new amount:");
                        int.TryParse(Console.ReadLine(), out amount);

                        cart = bl.cart.UpdateProductInCart(cart, id, amount);
                        #endregion
                        break;
                    case 3:
                        #region case 3
                        Console.WriteLine("insert name:");
                        cart!.CustomerName = Console.ReadLine();

                        Console.WriteLine("insert email :");
                        cart.CustomerEmail = Console.ReadLine();

                        Console.WriteLine("insert address:");
                        cart.CustomerAddress = Console.ReadLine();

                        bl.cart.MakeCart(cart);
                        #endregion
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("ERROR- your choice does not exist");
                        break;
                }
                if (choice == 0)
                    break;
            }
            
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
    static void TestBoOrder()
    {
        int choice = 1;

        while (choice != 0)
        {
            try
            {
                Console.WriteLine("Enter your choice:\n" +
                    "0-exit\n" +
                    "1-get order list\n" +
                    "2-get order by ID\n" +
                    "3-update ship date order\n" +
                    "4-update provision date order \n" +
                    "5-track order\n");
                //    "6-update order\n");
                bool flag = int.TryParse(Console.ReadLine(), out choice);
                BO.Product temp = new BO.Product();
                int id;
               // int amount;

                switch (choice)
                {
                    case 1:
                        #region case 1
                        var p = bl.Order.getOrderForList();
                        foreach (var item in p)
                            Console.WriteLine(item?.ToStringProperty());
                        #endregion
                        break;
                    case 2:
                        #region case 2
                        Console.WriteLine("insert id to get order:");
                        int.TryParse(Console.ReadLine(), out id);
                        Console.WriteLine(bl.Order.GetOrder(id));
                        #endregion
                        break;
                    case 3:
                        #region case 3
                        Console.WriteLine("insert id to update ship date:");
                        int.TryParse(Console.ReadLine(), out id);

                        Console.WriteLine(bl.Order.UpdateShipOrder(id));
                        #endregion
                        break;
                    case 4:
                        #region case 4
                        Console.WriteLine("insert id to update provision date:");
                        int.TryParse(Console.ReadLine(), out id);

                        Console.WriteLine(bl.Order.UpdateProvisionOrder(id));
                        #endregion
                        break;
                    case 5:
                        #region case 5
                        Console.WriteLine("insert order id to track:");
                        int.TryParse(Console.ReadLine(), out id);

                        Console.WriteLine(bl.Order.TrackOrder(id));
                        #endregion
                        break;
                    //case 6:
                    //    #region case 6
                    //    InsertProductDetails(ref temp);

                    //    Console.WriteLine("insert amount to update order:");
                    //    int.TryParse(Console.ReadLine(), out amount);

                    //    Console.WriteLine(bl.Order.UpdateOrder(temp, amount));
                    //    #endregion
                    //    break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("ERROR- your choice does not exist");
                        break;
                }
                if (choice == 0)
                    break;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    static void InsertProductDetails(ref BO.Product temp)
    {
        int detail;
        string? n;
        int cat;
        double price;

        Console.WriteLine("insert product details:");

        Console.WriteLine("id:");
        int.TryParse(Console.ReadLine(), out detail);
        temp.ID = detail;

        Console.WriteLine("name:");
        n = Console.ReadLine();
        temp.Name = n;

        Console.WriteLine("price:");
        double.TryParse(Console.ReadLine(), out price);
        temp.Price = price;

        Console.WriteLine("choose product catgory:\n" +
            "0-kids books\n" +
            "1-teens books\n" +
            "2-cook books\n" +
            "3-kodesh books\n" +
            "4-learning books\n");

        int.TryParse(Console.ReadLine(), out cat);

        switch (cat)
        {
            case 0:
                temp.Category = BO.Category.kids;
                break;
            case 1:
                temp.Category = BO.Category.teens;
                break;
            case 2:
                temp.Category = BO.Category.cook;
                break;
            case 3:
                temp.Category = BO.Category.kodesh;
                break;
            case 4:
                temp.Category = BO.Category.learn;
                break;
            default:
                Console.WriteLine("ERROR- category does not exist");
                break;
        }

        Console.WriteLine("product in stock:");
        int.TryParse(Console.ReadLine(), out detail);
        temp.InStock = detail;
    }
    static void Main(string[] args)
    {
        int choice = 1;
        while (choice != 0)
        {
            Console.WriteLine("Enter your choice:\n" +
                "0-exit\n" +
                "1-test BoProduct\n" +
                "2-test BoCart\n" +
                "3-test BoOrder\n");
            bool flag = int.TryParse(Console.ReadLine(), out choice);
            switch (choice)
            {
                case 1:
                    TestBoProduct();
                    break;
                case 2:
                    TestBoCart();
                    break;
                case 3:
                    TestBoOrder();
                    break;
                case 0:
                    break;
                default:
                    Console.WriteLine("ERROR- your choice does not exist");
                    break;
            }
            if (choice == 0)
                break;
        }
    }
}