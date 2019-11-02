using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Assignment4;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : Controller
    {
        private DataService ds = new DataService();


      /*  public string Index()  //ActionResult Index()
        {

            return "Product Index";   //View();
        }*/


        [HttpGet]
        public ActionResult GetProducts()
        {
            List<Product> products = ds.GetProducts();
            if (products.Count == 0) return NotFound();
            return Ok(products);
        }

        [HttpGet("{productId}")]
        public ActionResult GetProduct(int productId)
        {
            var product = ds.GetProduct(productId);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpGet("text/{query}")]
        public ActionResult SearchProduct(string query)
        {
            List<Product> products = ds.GetProductByName(query);
            if (products.Count == 0) return NotFound();

            return Ok(products);
        }


        [HttpGet("category/{cat}")]
        public ActionResult GetProductsByCategory(int cat)
        {
            List<Product> products = ds.GetProductByCategory(cat);
            Console.WriteLine(products.Count);
            if (products.Count == 0) return NotFound();
            
            return Ok(products);
        
        }
    }

}