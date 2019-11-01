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


        public string Index()  //ActionResult Index()
        {

            return "Product Index";   //View();
        }


        //Get all products TODO: Refactor
        [HttpGet]
        public ActionResult GetProducts()
        {
            using var db = new NorthwindContext();
                        
            return Ok(db.Products.ToArray());
        }

        [HttpGet("{productId}")]
        public ActionResult GetProduct(int productId)
        {
            var product = ds.GetProduct(productId);
            if (product == null) return NotFound();
            return Ok(product);
        }

    }
}