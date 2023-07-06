using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
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
        private readonly IGenericRepository<Product> _productsRepo;
        private readonly IGenericRepository<ProductBrand> _productBrandRepo;
        private readonly IGenericRepository<ProductType> _productTypeRepo;
        public ProductsController(IGenericRepository<Product> productsRepo, 
        IGenericRepository<ProductBrand> productBrandRepo, 
        IGenericRepository<ProductType> productTypeRepo)
        {
            _productTypeRepo = productTypeRepo;
            _productBrandRepo = productBrandRepo;
            _productsRepo = productsRepo;

        }

        //endpoints
        // task helps the api to handle multiple requests at the same time
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts() //remember the access pont will be https://localhost:5001/api/products
        {
            var spec = new ProductsWithTypesAndBrandsSpecification();
            var products = await _productsRepo.ListAsync(spec);
            return Ok(products);
        }

        

        [HttpGet("{id}")] //example passing a parameter. This is one level deeper https://localhost:5001/api/products/2
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return await _productsRepo.GetByIdAsync(id);
        }


        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands(){
            return Ok(await _productBrandRepo.ListAllAsync());
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes(){
            return Ok(await _productTypeRepo.ListAllAsync());
        }
    }
}