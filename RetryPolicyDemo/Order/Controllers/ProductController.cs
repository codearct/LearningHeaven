using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order.Services;

namespace Order.Controllers
{
    [Route("products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("{id}")]
        public ActionResult<string> GetProductById(int id)
        {
            var result = _productService.GetProductById(id);
            if(result == null) return NotFound("Product was not found");
            return Ok(result);
        }
    }
}
