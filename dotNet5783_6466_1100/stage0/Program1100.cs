using System;

namespace stage0
{
   partial class Program
    {
        static void Main(string[] args)
        {
            welcome1100();
            welcome6466();  
            Console.ReadKey();

        }

        static partial void welcome6466();
        private static void welcome1100()
        {
            Console.Write("enter your name:");
            string name = Console.ReadLine();
            Console.WriteLine("{0},welcome to my first console application", name);
        }
    }
}
