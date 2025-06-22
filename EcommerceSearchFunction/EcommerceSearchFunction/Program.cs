using EcommerceSearchFunction;
using System;
public class Program
{
    public static void Main()
    {
        Product[] products = new Product[] {
            new Product(5, "Pen", "Stationery"),
            new Product(3, "TV", "Electronics"),
            new Product(2, "Slipper", "Footwear"),
            new Product(4, "Book", "Stationery"),
            new Product(1, "Saree", "Fashoin")
        };
        Console.WriteLine("Enter ID to search");
        int findID;
        bool valid = int.TryParse(Console.ReadLine(), out findID);
        if (!valid)
        {
            Console.WriteLine("Not found");
            return;
        }
        Console.WriteLine("By Linear Search");
        Product find1 = Search.LinearSearch(products, findID);
        Console.WriteLine(find1 != null ? "Yes available " + find1 : "Not found");

        Array.Sort(products, (a, b) => a.PID.CompareTo(b.PID));
        Console.WriteLine("By Binary Search");
        Product find2 = Search.LinearSearch(products, findID);
        Console.WriteLine(find2 != null ? "Yes available " + find2 : "Not found");
    }
}



