using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Payment.Controllers
{
    [Route("payments")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {

        [HttpGet("{productName}")]
        public ActionResult<string> PayForProductName(string productName)
        {
            ThrowRandomException();
            return Ok($"Payment is successed for {productName}");
        }

        private void ThrowRandomException()
        {
            var randomNumber = new Random().Next(0, 10);
            if (randomNumber > 5)
            {
                throw new Exception();
            }
        }
    }
}
