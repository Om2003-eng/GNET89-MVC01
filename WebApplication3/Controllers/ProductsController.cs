using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    //[Route("Test")]
    public class ProductsController : Controller
    {

        [HttpGet("Json")]

        public IActionResult JsonAction()
        {
            return Json("Hello From JSON Action");
        }
        [HttpGet("ProductByCode/{code:int}")]

        public IActionResult GetProductByCode(int code)
        {
            return Json(new Product()
            {
                Id = code,
                Name="Laptop"
            });
        }
        public IActionResult Index()
        {
            return View();
        }

       
        public JsonResult GetProducts()
        {
            var products = new List<Product>
            {
                new Product(){Id=1, Name="Laptop"},
                new Product(){Id=2, Name="Keyboard"},
            };
            return Json(products);
        }
        public IActionResult GetProduct([FromQuery] int id, [FromQuery(Name ="id02")] int anotherId)
        {
            return Json(new {id, anotherId });
        }

        public IActionResult GetProductById(int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }
            else if (id == 0)
            {
                return RedirectToAction("Index");
            }

            else if (id < 10)
            {
                return NotFound();
            }

            else
            {
                return Json(new Product()
                {
                    Id = id,
                    Name="Laptop"
                });
            }
        }

        public IActionResult RedirectAction()
        {
            return Redirect("https://www.youtube.com/");
        }
        public IActionResult Search(ProductFilter filter)
        {
            return View();
        }
    }
}
