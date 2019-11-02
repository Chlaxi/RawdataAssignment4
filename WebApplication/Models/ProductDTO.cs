using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment4;

namespace WebApplication
{
    public class ProductDTO
    {
        public string Link { get; set; }
        public string Name { get; set; }
        public string ProductName { get; set; }
        public int UnitPrice { get; set; }
        public string QuantityPerUnit { get; set; }
        public int UnitsInStock { get; set; }

        public Category Category { get; set; }

        public string CategoryName { get { return Category.Name; } }
    }
}
