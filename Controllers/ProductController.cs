using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pharmacy_POS_System.Data;
using Pharmacy_POS_System.Entities;
using Pharmacy_POS_System.DAL.Interface;

namespace Pharmacy_POS_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public IProductRepository _irepo;
        public PharmacyDbContext _context;
        public IWebHostEnvironment _environment;
        public ProductController(IProductRepository repository, PharmacyDbContext context, IWebHostEnvironment environment)
        {
            _irepo = repository;
            _context = context;
            _environment = environment;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult<IEnumerable<Product>>> Index()
        {
            var products = await _irepo.Get();
            return Ok(products);
        }

        [HttpGet("Get/{id}")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            var division = await _irepo.Get(id);
            return Ok(division);
        }

        [HttpPost("Post")]
        public async Task<ActionResult<Product>> CreateProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                var products = await _irepo.Post(product);
                return Ok(products);
            }
            return BadRequest();
        }

        [HttpPut("Put/{id}")]
        public async Task<IActionResult> Put([FromForm]int id, Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _irepo.Put(id, product);
            return Ok(product);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
