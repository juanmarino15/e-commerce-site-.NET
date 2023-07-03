using Core.Entities;
using Core.Interfaces;
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
        private readonly IProductRepository _repo;
        public ProductsController(IProductRepository repo)
        {
            _repo = repo;   
        }

        //endpoints
        // task helps the api to handle multiple requests at the same time
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts() //remember the access pont will be https://localhost:5001/api/products
        {
            var products = await _repo.GetProductsAsync();
            return Ok(products);
        }

        

        [HttpGet("{id}")] //example passing a parameter. This is one level deeper https://localhost:5001/api/products/2
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return await _repo.GetProductByIdAsync(id);
        }
    }
}