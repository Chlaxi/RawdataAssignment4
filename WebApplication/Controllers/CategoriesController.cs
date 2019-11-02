using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Assignment4;
using Microsoft.EntityFrameworkCore;

namespace WebApplication.Controllers
{
    [Route("api/categories")]
    public class CategoriesController : Controller
    {

        private DataService ds = new DataService();

       

        [HttpGet]
        public ActionResult GetCategories()
        {
            List<Category> categories = ds.GetCategories();
            if (categories.Count == 0) return NotFound();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public ActionResult GetCategory(int id)
        {
            Category category = ds.GetCategory(id);
            if (category == null) return NotFound();
            return Ok(category);
        }

        [HttpPost]
        public ActionResult CreateCategory(string name, string description)
        {
            Category category = ds.CreateCategory(name, description);
            if (category == null) return null;
            return Created(category.ToString(),category);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCategory(int id, string name, string description)
        {
            bool result = ds.UpdateCategory(id, name, description);
            if (!result) return NotFound();
            return Ok(ds.GetCategory(id));
        }

        [HttpDelete("{id}")]
        public ActionResult UpdateCategory(int id)
        {
            bool result = ds.DeleteCategory(id);
            System.Console.WriteLine(result);
            if (!result) return NotFound();
            return Ok();
        }

    }
}