using Dal;
using DalApi;
using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Program
{/// <summary>
/// function- test order actions 
/// </summary>
/// <param name="order"></param>
    static void TestOrder(DalOrder order)
    {
        try
        {
            int choice = 1;
            int i;
            while (choice != 0)
            {
                Console.WriteLine(@"
                Enter your choice:
                0-exit
                1-add order
                2-get order by ID
                3-get all the orders
                4-update order
                5-delete order from list");
                bool flag = int.TryParse(Console.ReadLine(), out choice);
                int detail;
                string n;
                int id;
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("insert order details:");
                        Order temp = new Order();
                        Console.WriteLine("id:");
                        int.TryParse(Console.ReadLine(), out detail);
                        temp.ID = detail;
                        Console.WriteLine("customer name:");
                        n = Console.ReadLine();
                        temp.CustomerName = n;
                        Console.WriteLine("customer email:");
                        n = Console.ReadLine();
                        temp.CustomerEmail = n;
                        Console.WriteLine("customer adress:");
                        n = Console.ReadLine();
                        temp.CustomerAddress = n;
                        order.Add(temp);
                        break;
                    case 2:
                        Console.WriteLine("insert id to get order:");
                        int.TryParse(Console.ReadLine(), out id);
                        order.GetByID(id);
                        Console.WriteLine(order.GetByID(id));
                        break;
                    case 3:
                        var list= order.getAll();
                        foreach (var item in list)Console.WriteLine(item.ToString());


                        break;

                    case 4:
                        Console.WriteLine("insert order details:");
                        Order temp1 = new Order();
                        Console.WriteLine("id:");
                        int.TryParse(Console.ReadLine(), out id);
                        temp1.ID = id;
                        Console.WriteLine(order.GetByID(id));
                        Console.WriteLine("costumer name:");
                        temp1.CustomerName = Console.ReadLine();
                        Console.WriteLine("costumer email:");
                        temp1.CustomerEmail = Console.ReadLine();
                        Console.WriteLine("costumer adress:");
                        temp1.CustomerAddress = Console.ReadLine();
                        order.Update(temp1);
                        break;
                    case 5:
                        Console.WriteLine("insert id to delete order:");
                        int.TryParse(Console.ReadLine(), out id);
                        order.Delete(id);
                        break;
                    case 0:
                        break;
                }
                if (choice == 0)
                    break;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        
    }
    /// <summary>
    ///function- test order items actions
    /// </summary>
    /// <param name="orderItem"></param>
    static void TestOrderItem(DalOrderItem orderItem)
    {
        try
        {
            int choice = 1;
            int i;
            while (choice != 0)
            {
                Console.WriteLine(@"
                Enter your choice:
                0-exit
                1-add order item
                2-get order item by ID
                3-get all order items 
                4-update order item
                5-delete order item from list");
                bool flag = int.TryParse(Console.ReadLine(), out choice);
                int detail;
                string n;
                int id;
                double price;
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("insert order details:");
                        OrderItem temp = new OrderItem();
                        Console.WriteLine("id:");
                        int.TryParse(Console.ReadLine(), out detail);
                        temp.ID = detail;
                        Console.WriteLine("product id:");
                        int.TryParse(Console.ReadLine(), out detail);
                        temp.ProductID = detail;
                        Console.WriteLine("order id:");
                        int.TryParse(Console.ReadLine(), out detail);
                        temp.OrderID = detail;
                        Console.WriteLine("price:");
                        double.TryParse(Console.ReadLine(), out price);
                        temp.Price = price;
                        Console.WriteLine("amount:");
                        int.TryParse(Console.ReadLine(), out detail);
                        temp.Amount = detail;
                        orderItem.Add(temp);
                        break;
                    case 2:
                        Console.WriteLine("insert id to get order item:");
                        int.TryParse(Console.ReadLine(), out id);
                        orderItem.GetByID(id);
                        Console.WriteLine(orderItem.GetByID(id));
                        break;
                    case 3:
                        var list = orderItem.getAll();
                        foreach (var item in list) Console.WriteLine(item.ToString());
                        break;

                    case 4:
                        Console.WriteLine("insert order details:");
                        OrderItem temp1 = new OrderItem();
                        Console.WriteLine("id:");
                        int.TryParse(Console.ReadLine(), out detail);
                        temp1.ID = detail;
                        Console.WriteLine("product id:");
                        int.TryParse(Console.ReadLine(), out detail);
                        temp1.ProductID = detail;
                        Console.WriteLine("order id:");
                        int.TryParse(Console.ReadLine(), out detail);
                        temp1.OrderID = detail;
                        Console.WriteLine("price:");
                        double.TryParse(Console.ReadLine(), out price);
                        temp1.Price = price;
                        Console.WriteLine("amount:");
                        int.TryParse(Console.ReadLine(), out detail);
                        temp1.Amount = detail;
                        orderItem.Update(temp1);
                        break;
                    case 5:
                        Console.WriteLine("insert id to delete order:");
                        int.TryParse(Console.ReadLine(), out id);
                        orderItem.Delete(id);
                        break;
                    case 0:
                        break;
                }
                if (choice == 0)
                    break;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    /// <summary>
    /// function- test product actions
    /// </summary>
    /// <param name="product"></param>
    static void TestProduct(DalProduct product)
    {
        try
        {
            int choice = 1;
            int i;
            while (choice != 0)
            {
                Console.WriteLine(@"
                Enter your choice:
                0-exit
                1-add product
                2-get product by ID
                3-get all product  
                4-update product
                5-delete product from list");
                bool flag = int.TryParse(Console.ReadLine(), out choice);
                int detail;
                string n;
                int cat;
                int id;
                double price;
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("insert product details:");
                        Product temp = new Product();
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
                                        0-phones, 
                                        1-gadgets, 
                                        2-audio, 
                                        3-tablets, 
                                        4-smart Watchs");
                        int.TryParse(Console.ReadLine(), out cat);

                        switch (cat)
                        {
                            case 0:
                                temp.Category = Category.phone;
                                break;
                            case 1:
                                temp.Category = Category.Gadget;
                                break;
                            case 2:
                                temp.Category = Category.audio;
                                break;
                            case 3:
                                temp.Category = Category.tablet;
                                break;
                            case 4:
                                temp.Category = Category.smartWatch;
                                break;
                            default:
                                Console.WriteLine("ERROR- category does not exist");
                                break;
                        }

                        Console.WriteLine("product in stock:");
                        int.TryParse(Console.ReadLine(), out detail);
                        temp.InStock = detail;
                        product.Add(temp);
                        break;
                    case 2:
                        Console.WriteLine("insert id to get product:");
                        int.TryParse(Console.ReadLine(), out id);
                        product.GetByID(id);
                        Console.WriteLine(product.GetByID(id));
                        break;
                    case 3:
                        var list = product.getAll();
                        foreach (var item in list) Console.WriteLine(item.ToString());
                        break;

                    case 4:
                        Console.WriteLine("insert product details:");
                        Product temp1 = new Product();
                        Console.WriteLine("id:");
                        int.TryParse(Console.ReadLine(), out detail);
                        temp1.ID = detail;
                        Console.WriteLine("name:");
                        n = Console.ReadLine();
                        temp1.Name = n;
                        Console.WriteLine("price:");
                        double.TryParse(Console.ReadLine(), out price);
                        temp1.Price = price;
                        Console.WriteLine(@"choose product catgory: 
                                        0-phones, 
                                        1-gadgets, 
                                        2-audio, 
                                        3-tablets, 
                                        4-smart Watchs");
                        int.TryParse(Console.ReadLine(), out cat);

                        switch (cat)
                        {
                            case 0:
                                temp1.Category = Category.phone;
                                break;
                            case 1:
                                temp1.Category = Category.Gadget;
                                break;
                            case 2:
                                temp1.Category = Category.audio;
                                break;
                            case 3:
                                temp1.Category = Category.tablet;
                                break;
                            case 4:
                                temp1.Category = Category.smartWatch;
                                break;
                            default:
                                Console.WriteLine("ERROR- category does not exist");
                                break;
                        }

                        Console.WriteLine("product in stock:");
                        int.TryParse(Console.ReadLine(), out detail);
                        temp1.InStock = detail;
                        product.Update(temp1);
                        break;
                    case 5:
                        Console.WriteLine("insert id to delete product:");
                        int.TryParse(Console.ReadLine(), out id);
                        product.Delete(id);
                        break;
                    case 0:
                        break;

                    if (choice == 0)
                            break;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    /// <summary>
    /// funcion- Main 
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args)
	{
        DalOrder order = new DalOrder();
        DalOrderItem orderItem= new DalOrderItem();
        DalProduct product=new DalProduct();

		int choice = 1;
		while (choice != 0)
		{
            Console.WriteLine(@"
                Enter your choice:
                0-exit
                1-test Order
                2-test OrderItem
                3-test Product");
            bool flag=int.TryParse(Console.ReadLine(), out choice);
            switch (choice)
            {
                case 1:
                    TestOrder(order);
                    break;
                case 2:
                    TestOrderItem(orderItem);
                    break;
                case 3:
                    TestProduct(product);
                    break;
                case 0:
                    break;
            }
            if (choice == 0)
                break;
        }
	}
}