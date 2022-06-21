using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        // [HttpGet]
        // public ActionResult<IEnumerable<Product>> GetAllProducts() {
        //     return Ok(this._context.Products.ToArray());
        // }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts() {
            var products = await this._context.Products.ToArrayAsync();
            return Ok(products);
        }


        [HttpGet, Route("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id) {
            var product = await _context.Products.FindAsync(id);
            if (product == null) {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product) {
            
            this._context.Products.Add(product);
            await this._context.SaveChangesAsync();

            return CreatedAtAction(
                "GetProduct",
                new { id = product.Id},
                product);
        } 
    }
}
