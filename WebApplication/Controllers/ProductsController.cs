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


        [HttpGet(Name = nameof(GetProducts))]
        public ActionResult GetProducts()
        {
            List<Product> products = ds.GetProducts();
            if (products.Count == 0) return NotFound();

            List<ProductDTO> productDTOs = GetDTOList(products);

            return Ok(productDTOs);
        }

        [HttpGet("{id}", Name = nameof(GetProduct))]
        public ActionResult GetProduct(int id)
        {
            var product = ds.GetProduct(id);
            if (product == null) return NotFound();

            return Ok(CreateProductDTO(product));
        }

        [HttpGet("name/{query}")]
        public ActionResult SearchProduct(string query)
        {
            List<Product> products = ds.GetProductByName(query);
            if (products.Count == 0) return NotFound(products);
            
            List<ProductDTO> productDTOs = GetDTOList(products);

            return Ok(productDTOs);
        }


        [HttpGet("category/{cat}")]
        public ActionResult GetProductsByCategory(int cat)
        {
            List<Product> products = ds.GetProductByCategory(cat);
            Console.WriteLine(products.Count);
            if (products.Count == 0) return NotFound(products);

            List<ProductDTO> productDTOs = GetDTOList(products);
            return Ok(productDTOs);       
        }


        public ProductDTO CreateProductDTO(Product product)
        {

            ProductDTO dto = new ProductDTO();
            dto.Link = Url.Link(
                    nameof(GetProduct),
                    new { id = product.Id });
            dto.Name = product.Name;
            dto.ProductName = product.Name;
            dto.QuantityPerUnit = product.QuantityPerUnit;
            dto.UnitPrice = product.UnitPrice;
            dto.UnitsInStock = product.UnitsInStock;
            dto.Category = product.Category;         

            return dto;
        }

        private List<ProductDTO> GetDTOList(List<Product> products)
        {
            List<ProductDTO> DTO = new List<ProductDTO>();
            foreach (var prod in products)
            {
                DTO.Add(CreateProductDTO(prod));
            }
            return DTO;
        }


    }

}