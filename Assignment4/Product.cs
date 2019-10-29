using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment4
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProductName {
            get { return Name; }
        }
        public int UnitPrice { get; set; }
        public string QuantityPerUnit { get; set; }
        public int UnitsInStock { get; set; }

        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { 
            get { return Category.Name; } 
        }
    }
}
