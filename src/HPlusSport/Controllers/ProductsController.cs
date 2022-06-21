using Microsoft.AspNetCore.Mvc;
using HPlusSport.API.Models;

namespace HPlusSport.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ShopContext _context;

        public ProductsController(ShopContext context) 
        {
            _context = context;

            _context.Database.EnsureCreated();
        }
        // [HttpGet]
        // public IEnumerable<Product> GetAllProducts() {
        //     return this._context.Products.ToArray();
        // }
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAllProducts() {
            return Ok(this._context.Products.ToArray());
        }
    }
}
