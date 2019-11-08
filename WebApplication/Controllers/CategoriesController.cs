using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Assignment4;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.EntityFrameworkCore;

namespace WebApplication.Controllers
{
    [Route("api/categories")]
    public class CategoriesController : Controller
    {

        private DataService ds = new DataService();
       

        [HttpGet(Name = nameof(GetCategories))]
        public ActionResult GetCategories()
        {
            List<Category> categories = ds.GetCategories();
            if (categories.Count == 0) return NotFound();

            List<CategoryDTO> DTO = GetDTOList(categories);

            return Ok(DTO);
        }

        [HttpGet("{id}", Name = nameof(GetCategory))]
        public ActionResult GetCategory(int id)
        {
            Category category = ds.GetCategory(id);
            if (category == null) return NotFound();

            return Ok(CreateCategoryDto(category));
        }

        
        [HttpPost]
        public ActionResult CreateCategory([FromBody] CategoryForCreation cat)
        {
            
            Category category = ds.CreateCategory(cat.Name, cat.Description);
            if (category == null) return NotFound();

            return CreatedAtRoute(nameof(GetCategory), new { id = category.Id }, category);
        }


        [HttpPut("{id}")]
        public ActionResult UpdateCategory(int id, [FromBody] CategoryForCreation cat)
        {
            bool result = ds.UpdateCategory(id, cat.Name, cat.Description);
            if (!result) return NotFound();

            return Ok(CreateCategoryDto(ds.GetCategory(id)));
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCategory(int id)
        {
            bool result = ds.DeleteCategory(id);
            System.Console.WriteLine(result);
            if (!result) return NotFound();

            return Ok();
        }



        public CategoryDTO CreateCategoryDto(Category category)
        {
            CategoryDTO dto = new CategoryDTO();
            dto.Link = Url.Link(
                    nameof(GetCategory),
                    new { id = category.Id }).ToString();
            System.Console.WriteLine(dto.Link.ToString());
            dto.Name = category.Name;
            dto.Description = category.Description;
            return dto;
        }

        private List<CategoryDTO> GetDTOList(List<Category> categories)
        {
            List<CategoryDTO> DTO = new List<CategoryDTO>();
            foreach (var cat in categories)
            {
                DTO.Add(CreateCategoryDto(cat));
            }
            return DTO;
        }
    }
}