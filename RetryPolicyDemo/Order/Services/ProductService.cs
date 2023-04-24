using Order.Repositories;
using Order.Services.FaultPolicies;
using Polly;
using Polly.Retry;
using System;

namespace Order.Services
{
    public interface IProductService
    {
        string GetProductById(int id);
        string GetProductByIdWithoutWrap(int id);
    }
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IFaultPolicy _faultPolicy;
        public ProductService(IProductRepository productRepository, IFaultPolicy faultPolicy)
        {
            _productRepository = productRepository;
            _faultPolicy = faultPolicy;
        }

        public string GetProductById(int id)
        {
            return _faultPolicy.Retry<string>(() => _productRepository.GetProductById(id));
        }

        public string GetProductByIdWithoutWrap(int id)
        {
            return Policy
                  .Handle<Exception>()
                  .WaitAndRetry(3, input =>
                  {
                      var durationTime = TimeSpan.FromSeconds(Math.Pow(2, input)) + TimeSpan.FromMilliseconds(new Random().Next(0, 100));
                      return durationTime;
                  }, (result, timeSpan, retryCount,context) =>
                  {
                      if (result != null)
                          Console.WriteLine($"Request failed with --{result.Message}--.Waiting {timeSpan} before next retry.Retry attempt {retryCount}");
                      else
                          Console.WriteLine($"Request failed with unknown reason.Waiting {timeSpan} before next retry.Retry attempt {retryCount}");
                  })
                  .Execute<string>(() => _productRepository.GetProductById(id));
                            
        }
    }
}
