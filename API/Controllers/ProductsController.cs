using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController: ControllerBase
    {
        //endpoints
        [HttpGet]
        public string GetProducts() //remember the access pont will be https://localhost:5001/api/products
        {
            return "this will be a list of products";
        }

        [HttpGet("{id}")] //example passing a parameter. This is one level deeper https://localhost:5001/api/products/2
        public string GetProduct(int id)
        {
            return "this will be a products";
        }
    }
}