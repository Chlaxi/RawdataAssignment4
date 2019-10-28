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
            using var db = new NorthwindContext();

            var order = db.Orders.Find(id);

            if (order == null)
                return null;

            return order;

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
            using var db = new NorthwindContext();
            var product = db.Products.Find(id);
            int cid = product.CategoryId;
            product.CategoryName = (from cat in db.Categories where cat.Id == cid select cat.Name).ToString();


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
            using var db = new NorthwindContext();

            var cat = db.Categories.Find(id);

             if(cat == null)
                return null;

             return cat;
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
            using var db = new NorthwindContext();

            var newId = db.Categories.Max(x => x.Id) + 1;

            var cat = new Category
            {
                Id = newId,
                Name = name,
                Description = description
            };

            Console.WriteLine("Created a new Category with id: " + newId + ", Name: " + cat.Name + ", Description: " + cat.Description);
            db.Categories.Add(cat);
  //          db.SaveChanges();
            return cat;
        }

        //12.
        public bool UpdateCategory(int id, string name, string description)
        {
            using var db = new NorthwindContext();

            var cat = db.Categories.Find(id);
            if (cat == null)
            {
                Console.WriteLine("Item with id " + id + " was not found");
                return false;
            }

            Console.WriteLine("Updated item with id " + id + ". \n Name: from: " + cat.Name + " to " + name + "\n Description from: " + cat.Description + " to " + description);
            cat.Name = name;
            cat.Description = description;
 //           db.SaveChanges();
            return true;
        }

        //13.
        public bool DeleteCategory(int id)
        {
            using var db = new NorthwindContext();

            var cat = db.Categories.Find(id);
            if (cat == null)
            {
                Console.WriteLine("Item with id " + id + " was not found");
                return false;
            }

            Console.WriteLine("Removing "+ cat.ToString());
            db.Remove(cat);
//            db.SaveChanges();
            return true;
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
