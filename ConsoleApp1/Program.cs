using System;
using Assignment4;
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var ds = new DataService();
            ds.CreateCategory("Test", "DeleteCategory_ValidId_RemoveTheCategory");
            foreach (var category in ds.GetCategories())
            {
                Console.WriteLine($"{category.Id} {category.Name}");
            }



            ds.UpdateCategory(9, "Updated name", "Updated description!");

            foreach (var category in ds.GetCategories())
            {
                Console.WriteLine($"{category.Id} {category.Name}");
            }

            ds.DeleteCategory(9);
            /*
            var q = ds.GetProduct(1);
            if (q == null)
                Console.WriteLine("q was null");
            else
                Console.WriteLine($"{q.Id }{q.Name }{ q.UnitPrice}");
            */
            foreach (var category in ds.GetCategories())
            {
                Console.WriteLine($"{category.Id} {category.Name}");
            }
        }
    }
}
