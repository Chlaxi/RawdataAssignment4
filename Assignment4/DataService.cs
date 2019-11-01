using System;
using System.Collections;
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
        /* TODO Return the complete order, i.e. all attributes of the order, the complete list of
order details. Each order detail should include the product which must include
the category.*/
        public Order GetOrder(int id)
        {

            using var db = new NorthwindContext();

            var order = db.Orders.Find(id);
            order.OrderDetails = GetOrderDetailsByOrderId(id);
            
            Console.WriteLine("Order Id: {0}, shipped on {1}, has {2} details. It was sent to {3} with the ship {4}",
                order.Id, order.Date, order.OrderDetails.Count, order.ShipCity, order.ShipName);
            foreach (var detail in order.OrderDetails){
                Console.WriteLine("Product: {0} (ID: {1}). Unit price = {2}, quantity of {3} with a discount of {4}", detail.Product.Name, detail.ProductId, detail.UnitPrice, detail.Quantity, detail.Discount);
                Console.WriteLine("The product is of the {0} category", detail.Product.CategoryName);
            }

            return order;

        }

        //2.
        /// <summary>
        /// Return a list of orders with id, date, ship name and city
        /// </summary>
        /// <param name="shipName">The name of the ship</param>
        /// <returns></returns>
        public List<Order> GetOrdersByShipping(string shipName)
        {
            using var db = new NorthwindContext();

            var ordersByShip = from order in db.Orders
                               where order.ShipName.Contains(shipName)
                               select new
                               {
                                   order.Id,
                                   order.Date,
                                   order.ShipName,
                                   order.ShipCity
                               };

            var orderArr = ordersByShip.ToArray();

            if(orderArr.Length < 0)
            {
                Console.WriteLine("Array is empty. Returning null");
                return null;
            }

            List<Order> orderList = new List<Order>();
            foreach (var o in orderArr)
            {
                Order newOrder = new Order()
                {
                    Id = o.Id,
                    Date = o.Date,
                    ShipName = o.ShipName,
                    ShipCity = o.ShipCity
                };
                orderList.Add(newOrder);
            }

            return orderList;
        }

        //3.
        /// <summary>
        /// Return a list of orders
        /// </summary>
        /// <returns></returns>
        public List<Order> GetOrders()
        {
            using var db = new NorthwindContext();

            List<Order> orders = new List<Order>();

            var orderQ = from order in db.Orders
                               select new
                               {
                                   order.Id,
                                   order.Date,
                                   order.ShipName,
                                   order.ShipCity
                               };

            var orderArr = orderQ.ToArray();
            Console.WriteLine(orderArr.Length+" elements in array");
            if (orderArr.Length < 0)
            {
                Console.WriteLine("Array is empty. Returning null");
                return null;
            }

            List<Order> orderList = new List<Order>();
            foreach (var o in orderArr)
            {
                Order newOrder = new Order()
                {
                    Id = o.Id,
                    Date = o.Date,
                    ShipName = o.ShipName,
                    ShipCity = o.ShipCity
                };
                orderList.Add(newOrder);
            }

            return orderList;

        }

        //OrderDetail
            
        //4.
        /// <summary>
        /// Return the order details for an order with product name, unit price, quantity.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<OrderDetails> GetOrderDetailsByOrderId(int id)
        {

            using var db = new NorthwindContext();

            var orderDetails = from details in db.OrderDetails
                               join product in db.Products on details.ProductId equals product.Id
                               join order in db.Orders on details.OrderId equals order.Id
                               where details.OrderId == id
                               select new
                               {
                                   Order = order,
                                   details.OrderId,
                                   ProductId = product.Id,
                                   details.UnitPrice,
                                   details.Quantity,
                                   details.Discount    
                               };

            List<OrderDetails> result = new List<OrderDetails>();
            Console.WriteLine("Order with id "+id+" contains");
            foreach(var detail in orderDetails)
            {

                OrderDetails newOrder = new OrderDetails()
                {
                    Order = detail.Order,
                    Product = GetProduct(detail.ProductId),
                    UnitPrice = detail.UnitPrice,
                    Quantity = detail.Quantity,
                    ProductId = detail.ProductId,
                    Discount = detail.Discount,
                    OrderId = detail.OrderId
                    
                };
                result.Add(newOrder);
                Console.WriteLine("Product name: {0}", newOrder.Product.Name);
                Console.WriteLine("Price: {0}. quantity {1}", newOrder.UnitPrice, newOrder.Quantity);
                Console.WriteLine("Order Id: {0}", newOrder.Order.Id);
                Console.WriteLine("Date: {0}", newOrder.Order.Date);
                Console.WriteLine("{0}, at the price of {1} per piece. {2} was ordered with order id of {3} on {4}", newOrder.Product.Name, newOrder.UnitPrice, newOrder.Quantity, newOrder.Order.Id, newOrder.Order.Date);
            }

            return result;
        }

        //5.
        public List<OrderDetails> GetOrderDetailsByProductId(int id)
        {
            /* TODO Return the complete list of details, with order date, unit price, quantity */
            using var db = new NorthwindContext();

            var orderDetails = from details in db.OrderDetails
                               join product in db.Products on details.ProductId equals product.Id
                               join order in db.Orders on details.OrderId equals order.Id
                               where details.ProductId == id
                               select new
                               {
                                   Order = order,
                                   details.OrderId,
                                   details.ProductId,
                                   details.UnitPrice,
                                   details.Quantity,
                                   details.Discount
                               };

            int i = 0;
            List<OrderDetails> result = new List<OrderDetails>();            

            Console.WriteLine("Order with Product ids " + id + " contains");
            
            foreach (var detail in orderDetails)
            {
                Console.WriteLine("num "+i);
                Console.WriteLine("Order ID= "+db.Orders.Find(detail.OrderId).Id);
                OrderDetails newOrder = new OrderDetails()
                {
                    Order = detail.Order,
                    Product = GetProduct(detail.ProductId),
                    UnitPrice = detail.UnitPrice,
                    Quantity = detail.Quantity,
                    ProductId = detail.ProductId,
                    Discount = detail.Discount,
                    OrderId = detail.OrderId

                };
                i++;
                Console.WriteLine("{0}, at the price of {1} per piece. {2} was ordered with order id of {3} on {4}"
                    ,newOrder.Product.Name, newOrder.UnitPrice, newOrder.Quantity, newOrder.Order.Id, newOrder.Order.Date);
                Console.WriteLine();
                result.Add(newOrder);

            }
            


            return result;
        }

        //Product
        //6.
        /// <summary>
        /// Return the complete product with name, unit price and category name.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Product GetProduct(int id)
        {
            using var db = new NorthwindContext();

            var product = db.Products.Find(id);
            if (product == null)
            {
                Console.WriteLine("Product not found");
                return null;
            }
            Console.WriteLine("Product found!");

            var cat = GetCategory(product.CategoryId);

            product.Category = cat;
            Console.WriteLine("Category name for product "+ product.Name+" is set to "+product.CategoryName);

            return product;
        }

        //7.
        /// <summary>
        /// Search for products where the name matches the given substring. Return a list of product name and category name.
        /// </summary>
        /// <param name="name">A substring for the name</param>
        /// <returns></returns>
        public List<Product> GetProductByName(string name)
        {
            using var db = new NorthwindContext();

            List<Product> products = new List<Product>();


            var query = from prod in db.Products
                         where prod.Name.Contains(name)
                         select prod.Id;

            foreach (var i in query)
            {
                Product product = GetProduct(i);
                Console.WriteLine(product.ProductName + " " + product.Category.Name);
                products.Add(product);
            }

            return products;
        }

        //8.
        /// <summary>
        /// Return the list of products with the given category.
        /// </summary>
        /// <param name="id">The category id you want to search for.</param>
        /// <returns></returns>
        public List<Product> GetProductByCategory(int id)
        {
            using var db = new NorthwindContext();

            List<Product> products = new List<Product>();


            var query = from prod in db.Products
                        where prod.CategoryId == id
                        select prod.Id;

            foreach (var i in query)
            {
                Product product = GetProduct(i);
                Console.WriteLine(product.ProductName + " " + product.CategoryName);
                products.Add(product);
            }

            return products;
        }


    //Category
        //9.
        /// <summary>
        /// Returns a single category, based on an id
        /// </summary>
        /// <param name="id">The category id you are searching for</param>
        /// <returns></returns>
        public Category GetCategory(int id)
        {
            using (var db = new NorthwindContext())
            {
                var cat = db.Categories.Find(id);

                if (cat == null)
                    return null;

                return cat;
            }
        }

        //10.
        /// <summary>
        /// Returns all categories
        /// </summary>
        /// <returns></returns>
        public List<Category> GetCategories()
        {
            using var db = new NorthwindContext();        
            return db.Categories.ToList();
        }

        //11.
        /// <summary>
        /// Create a new category
        /// </summary>
        /// <param name="name">The category's name</param>
        /// <param name="description">The category's description</param>
        /// <returns>Returns the created category (id is auto generated)</returns>
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
            db.SaveChanges();
            return cat;
        }

        //12.
        /// <summary>
        /// Update the information on an existing category
        /// </summary>
        /// <param name="id">The identifier to find the category</param>
        /// <param name="name">The new name for the category</param>
        /// <param name="description">The new description for the category</param>
        /// <returns>Returns true if the update was successful </returns>
        public bool UpdateCategory(int id, string name, string description)
        {
            using (var db = new NorthwindContext())
            {
                var cat = db.Categories.Find(id);
                if (cat == null)
                {
                    Console.WriteLine("Item with id " + id + " was not found");
                    return false;
                }

                Console.WriteLine("Updated item with id " + id + ". \n Name: from: " + cat.Name + " to " + name + "\n Description from: " + cat.Description + " to " + description);
                cat.Name = name;
                cat.Description = description;
                db.SaveChanges();

                return true;
            }
        }

        //13.
        /// <summary>
        /// Delete an existing category
        /// </summary>
        /// <param name="id">The id of the category you want to delete</param>
        /// <returns>Returns true if the category was deleted</returns>
        public bool DeleteCategory(int id)
        {
            using var db = new NorthwindContext();

            var cat = GetCategory(id);
            if (cat == null)
            {
                Console.WriteLine("Item with id " + id + " was not found");
                return false;
            }

            Console.WriteLine("Removing "+ cat.ToString());
            db.Remove(cat);
            db.SaveChanges();
            return true;
        }
    }
}
