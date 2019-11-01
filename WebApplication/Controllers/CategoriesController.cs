using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    public class CategoriesController : Controller
    {
        [Route("api/categories")]
        public  string Index()// IActionResult Index()
        {
            return "Default test";// View();
        }
    }
}