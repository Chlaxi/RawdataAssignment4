using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Assignment4
{
    public class DataService
    {

    //Orders

            //1.
        public Order GetOrder(int id)
        {
            /* TODO Return the complete order, i.e. all attributes of the order, the complete list of
order details. Each order detail should include the product which must include
the category.*/
            return null;
        }

        //2.
        public List<Order> GetOrdersByShipping(string shipName)
        {
            /* TODO Return a list of orders with id, date, ship name and city */

            return null;
        }

        //3.
        public List<Order> GetOrders()
        {

            List<Order> orders = new List<Order>();

            /* TODO Return a list of orders with the same information as in 2. */

            return orders;

        }

        //OrderDetail
        //4.
        public OrderDetails GetOrderDetailsByOrderId(int id)
        {
            /* TODO Return the order details with product name, unit price, quantity.*/

            return null;
        }

        //5.
        public OrderDetails GetOrderDetailsByProductId(int id)
        {
            /* TODO Return the complete list of details, with order date, unit price, quantity */
            return null;
        }

        //Product
        //6.
        public Product GetProduct(int id)
        {
            var product = new Product();

            /* TODO Return the complete product with name, unit price and category name.*/

            return product;
        }

        //7.
        public List<Product> GetProductByName(string name)
        {
            List<Product> products = new List<Product>();


            /* TODO Search for products where the name matches the given substring. Return a list of
product name and category name.*/

            return products;

        }

        //8.
        public List<Product> GetProductByCategory(int id)
        {
            List<Product> products = new List<Product>();

            /* TODO Return the list of products with the given category. Return the same information
                as in 6. (name, unit price and category name.) Note Call GetProductByID for every instance?*/

            return products;
        }


    //Category
        //9.
        public Category GetCategory(int id)
        {
            /*TODO Implent following functionality:
            Return the category if found otherwise return null.
                */

            /*            foreach(Category cat in Categories)
                        {
                            if (id = cat.Id)
                                return cat;
                        }
            */
            return null;
        }

        //10.
        public List<Category> GetCategories()
        {
            using var db = new NorthwindContext();
            return db.Categories.ToList();
        }

        //11.
        public Category CreateCategory(string name, string description)
        {
            var cat = new Category();

            cat.Name = name;
            cat.Description = description;

            //TODO find highest ID (max(Id)), and set cat.Id=max(Id)+1);

            return cat;
        }

        //12.
        public bool UpdateCategory(int id, string name, string description)
        {
            //TODO Search all Ids. if not exists, return false.

            return false;

            //TODO for the object found, update the name and description. Return true.

        }

        //13.
        public bool DeleteCategory(int id)
        {
            //TODO Search all Ids. if not exists, return false.

            return false;

            //TODO delete Category with the id, and return true.
        }


    }

    class program
    {

       

        public static void Main()
        {
            var ds = new DataService();

            foreach (var category in ds.GetCategories())
            {
                Console.WriteLine($"{category.Id} {category.Name}");
            }
        }
    }

}



/*  HELPERS
            //using var db = new NorthwindContex();

            //var nextId = db.Categories.Max(x => x.Id) + 1;

            // Create 
            //var cat = new Category
            //{
            //    Id = nextId,
            //    Name = "Testing",
            //    Description = "blah blah ..."
            //};

            //db.Categories.Add(cat);

            // update
            //var cat = db.Categories.Find(9);

            //cat.Name = "Updating name";

            //var cat = db.Categories.Find(9);
            //db.Categories.Remove(cat);

            //db.SaveChanges();

            var ds = new DataService();


            foreach (var category in ds.GetCategories())
            {
                Console.WriteLine($"{category.Id} {category.Name}" );
            }
        } 
*/
