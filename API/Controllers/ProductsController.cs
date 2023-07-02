using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController: ControllerBase
    {
        //constructor
        private readonly StoreContext _context; //same as this.context
        public ProductsController(StoreContext context)
        {
            _context = context;
            
        }

        //endpoints
        // task helps the api to handle multiple requests at the same time
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts() //remember the access pont will be https://localhost:5001/api/products
        {
            var products = await _context.Products.ToListAsync();
            return products;
        }

        [HttpGet("{id}")] //example passing a parameter. This is one level deeper https://localhost:5001/api/products/2
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return await _context.Products.FindAsync(id);
        }
    }
}