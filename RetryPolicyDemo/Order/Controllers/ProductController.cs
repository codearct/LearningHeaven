using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order.Services;
using Order.Services.FaultPolicies;

namespace Order.Controllers
{
    [Route("products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IFaultPolicy _faultPolicy;
        private readonly IHttpClientFactory _httpClientFactory;
        private HttpClient _httpClient;
        private string apiUrl = "http://localhost:5100/";
        public ProductController(IProductService productService, IHttpClientFactory httpClientFactory, IFaultPolicy faultPolicy)
        {
            _productService = productService;
            _httpClientFactory = httpClientFactory;
            _faultPolicy = faultPolicy;
        }

        [HttpGet("{id}")]
        public ActionResult<string> GetProductById(int id)
        {
            var result = _productService.GetProductById(id);
            if (result == null) return NotFound("Product was not found");
            return Ok(result);
        }

        [HttpGet("nowrap/{id}")]
        public ActionResult<string> GetProductByIdWithoutWrap(int id)
        {
            var result = _productService.GetProductByIdWithoutWrap(id);
            if (result == null) return NotFound("Product was not found");
            return Ok(result);
        }

        [HttpGet("buy/{productName}")]
        public ActionResult<string> BuyProductByName(string productName)
        {
            _httpClient = _httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri(apiUrl);
            var uri = "payments/" + productName;
            var result = _faultPolicy.Retry<string>(() => _httpClient.GetStringAsync(uri).Result);

            return Ok(result);
        }
    }
}
